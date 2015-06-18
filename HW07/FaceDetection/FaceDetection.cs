using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using Emgu.CV.CvEnum;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Collections;
using System.IO;
using System.Drawing.Imaging;
using System.Globalization;



namespace CameraCapture
{
    public partial class FaceDetection : Form
    {   //Global Variables
        private Capture capturedCaptureFromWebcam;     //a capture from the webcam   
        private bool isCaptureInProgress; // if capture is in being captured?
        private HaarCascade faceHaar; // the data for the face features
        private HaarCascade eyeHaar;// the data for the eyes features
        private HaarCascade mouthHaar;// the data for the mouth features
        private bool cbFace; 
        private Bitmap originalImageFromPics; // the original image loaded bu user
        private Bitmap temporaryImageCopiedFromOriginal; // an image for temporary usages
        private Bitmap finalImage;// the image for showing after some detection
        private bool imageFit = false;
        // global fonts
        MCvFont faceFont = new MCvFont(Emgu.CV.CvEnum.FONT.CV_FONT_HERSHEY_SIMPLEX, 3.0, 3.0); // fonts for the dispaly
        MCvFont eyeFont = new MCvFont(Emgu.CV.CvEnum.FONT.CV_FONT_HERSHEY_SIMPLEX, 2.0, 2.0);// fonts for display
        MCvFont mouthFont = new MCvFont(Emgu.CV.CvEnum.FONT.CV_FONT_HERSHEY_SIMPLEX, 2.0, 2.0);// fonts for display
        

        public FaceDetection()
        {
            InitializeComponent(); // this method initialize the form components
            //cbFace = cbDetectFaceFile.Checked.ToString();
        }

        private void openButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    originalImageFromPics = new Bitmap(openFileDialog.FileName);

                    // Convert pixel format
                    originalImageFromPics = originalImageFromPics.Clone(new Rectangle(0, 0, originalImageFromPics.Width, originalImageFromPics.Height), PixelFormat.Format32bppArgb);
                    temporaryImageCopiedFromOriginal = new Bitmap(originalImageFromPics);

                    pictureBox.Image = originalImageFromPics;
                    pictureBox.Size = originalImageFromPics.Size;

                    // Resize window
                    int newWidth = Math.Max(this.PreferredSize.Width, 305);
                    int newHeight = this.PreferredSize.Height;
                    newWidth = Math.Min(newWidth, Screen.PrimaryScreen.Bounds.Width * 2 / 3);
                    newHeight = Math.Min(newHeight, Screen.PrimaryScreen.Bounds.Height * 2 / 3);
                    this.Size = new Size(newWidth, newHeight);
                    imageFit = false;
                }
                catch
                {
                    MessageBox.Show("Cannot open the file.");
                }

            }
        }
        
        private void fitButton_Click(object sender, EventArgs e)
        {
            temporaryImageCopiedFromOriginal = ScaleImage(originalImageFromPics, this.ClientRectangle.Width - pictureBox.Left - 3, this.ClientRectangle.Height - pictureBox.Top - 3);
            pictureBox.Image = temporaryImageCopiedFromOriginal;
            pictureBox.Size = temporaryImageCopiedFromOriginal.Size;
            imageFit = true;
            this.Size = this.PreferredSize;
        }

        private void DetectOrgansInFace(object sender, EventArgs arg)
        {
            #region
            /*
             * This function capture frams from the webcam and detects organs in it
             * the organs that is being detected are: Face, Eye, And mouth 
             * 
             */ 
            Image<Bgr, Byte> imageFrameCapturedFromCamera = capturedCaptureFromWebcam.QueryFrame(); // an image will be captured from the camera and will be processed
            if(imageFrameCapturedFromCamera!=null)
            {
                Image<Gray, byte> grayOfImageFrameCapturedFromCamera = imageFrameCapturedFromCamera.Convert<Gray, byte>();            
                // the processing will be done on the GRAY SCALE of the captured images bit the display is yet RGB
                
                if (cbDetectFaceFile.Checked) // checkBox to check if the user wants to detect the Face.
                {
                    var faces // an array that holds the faceS detected in the gray scal image
                        = grayOfImageFrameCapturedFromCamera.DetectHaarCascade(faceHaar, //the geometrical features of the face stored in XML format used for detection
                        1.4, // a good coeffient to detect the face
                        4, //a good coeffient to detect the face
                        HAAR_DETECTION_TYPE.DO_CANNY_PRUNING,
                        new Size(25, 25))[0];
                    foreach (var face in faces)
                    {
                        imageFrameCapturedFromCamera.Draw(face.rect, new Bgr(Color.Blue), 10); // draw a rectangle on the detected faces
                        int faceLableX=face.rect.X; // finding X left-top corner of the face for labeling
                        int faceLableY = face.rect.Y; // finding Y left-top corner of the face for labeling
                        Point p=new Point(faceLableX,faceLableY); // create a point to attach a lable "FACE" to the point
                        String s = "Face";// just a place holder for the "Face" that are goiong to be placed on the top-left corner of the face
                        imageFrameCapturedFromCamera.Draw(s, ref faceFont, p, new Bgr(Color.Blue)); // Add "Face" lable to the detected face
                        
                    }
                }

                if (cbDetectEyeFile.Checked)// checkBox to check if the user wants to detect the EYEs.
                {
                    var eyes // an araay that holds the detcted eyes and later on we will loop over them 
                        = grayOfImageFrameCapturedFromCamera.DetectHaarCascade(eyeHaar, // the geometrical features of the EYE are stored in the format of XML
                        4,// after trial and error this coeeffient is ok
                        3, // after trial and error this coefficient is ok
                        HAAR_DETECTION_TYPE.DO_CANNY_PRUNING,
                        new Size(1, 1))[0];
                    foreach (var eye in eyes) // more than one eye may be detected so for each eye there will be a rectangle
                    {
                        imageFrameCapturedFromCamera.Draw(eye.rect, new Bgr(Color.Red), 3); 
                        // for each detecte eye in the image a rectangle will be drawn on the image
                        int eyeLableX = eye.rect.X; // find the X top-left corner of the eye for labeling
                        int eyeLableY = eye.rect.Y; // find the Y top-left corneer of the eye for lableing 
                        Point p = new Point(eyeLableX, eyeLableY); // create a point p to attach the lable "EYE" to it
                        String e = "Eye"; // just a place holder for the string "EYE" 
                        imageFrameCapturedFromCamera.Draw(e, ref eyeFont, p, new Bgr(Color.Red)); // add a string "EYE" to the image captured from webcam just to be distingushable
                    }
                }

                if (cbDetectMouthFile.Checked)// checkBox to check if the user wants to detect the mouth.
                {
                    var mouths // an array to hold the detected MOUTHs
                        = grayOfImageFrameCapturedFromCamera.DetectHaarCascade
                        (mouthHaar, // the geometrical features for mouth stored in a XML format
                        5, // after some trial and error i found this coeffient isbetter
                        3, // after some trial and error i found this coefficient is better
                        HAAR_DETECTION_TYPE.DO_CANNY_PRUNING,
                        new Size(1, 1))[0];
                    foreach (var mouth in mouths) // loop over all the detected MOUTHs
                    {
                        imageFrameCapturedFromCamera.Draw(mouth.rect, new Bgr(Color.Black), 3);
                        // draw a recangle for each mouth and put it on the display
                        int mouthLableX = mouth.rect.X; // find the X top-left corner of the mouth for labling
                        int mouthLableY = mouth.rect.Y; // find the Y top-left corner of the mouth for labling
                        Point p = new Point(mouthLableX, mouthLableY); // create a point to attach the "MOUTH" lable to it
                        String m = "Mouth"; // just a place holder for string "MOUTH"
                        // add the string mouth to the top-left corner of the detected mouth
                        imageFrameCapturedFromCamera.Draw(m, ref mouthFont, p, new Bgr(Color.Black));
                    }
                }
                // display the image with the detected Face, Eye, Mouth based on user selection
                webCameraImageBoxRGB.Image = imageFrameCapturedFromCamera; // processed image will be displayed
            }
            #endregion
        }

        
        private void btnStart_Click(object sender, EventArgs e)
        {            
            //cbFace = cbDetectFaceFile.Checked;
            if (capturedCaptureFromWebcam == null)
            {
                try
                {//try to capture new captures by invocking the new Capture() method
                    capturedCaptureFromWebcam = new Capture();
                }
                catch (NullReferenceException excpt)
                {
                    MessageBox.Show(excpt.Message); 
                    // if the web cam is not ready so it transfered the error msg to the 
                    // display for the user. 
                    // to do list for myself: i should add another camera to
                    // capture the EAR form left and right. 
                }
            }           

            if (capturedCaptureFromWebcam != null)
            {
                if (isCaptureInProgress)
                {   // start capturing if the camera is not being used by any other application 
                    // and change the btnTxt to Start so user can start webcam
                    btnStart.Text = "Start Webcam"; //
                    Application.Idle -= DetectOrgansInFace;
                }
                else
                {
                    // capturing, so by press one more time it will pause/stop so
                    btnStart.Text = "Stop Webcam";
                    Application.Idle += DetectOrgansInFace;
                }

                isCaptureInProgress = !isCaptureInProgress;
            }
        }

        private void disposeDataFromTheMemory()
        {
            if (capturedCaptureFromWebcam != null)
                capturedCaptureFromWebcam.Dispose();
        }

        private void CameraCapture_Load(object sender, EventArgs e)
        {   // the XML files are loaded so no need for selection at this point
            // these are the files that storing the featurs for the 
            // i put them @C:\Dropbox\Dara\CLASS\CS740\HW\HW07\FaceDetection\bin\Debug
            // but it can be loaed wthile runing the code
           faceHaar = new HaarCascade("haarcascade_frontalface_alt_tree.xml");            
           eyeHaar = new HaarCascade("haarcascade_eye.xml"); 
           mouthHaar = new HaarCascade("haarcascade_Mouth.xml");

        }

        /*
         * this method loops over pixels Row*Column if the pixel is classified as
         * skin, it will not be any changes to the RGB values
         * if it is classifed as notSking it will be recolored as BLACK color pixel.
        */
        public static void DetectSkin(Bitmap originalImagePassed, ref Bitmap modifiedImageWithSkin)
        {
            /* reference of the paper:
             * http://www.cs.hmc.edu/~fleck/naked-skin.html
             * 
             * 
             *The RGB values are then transformed into log-opponent values I, Rg, and By 
             *as follows:
                L(x) = 105*log_10(x+1+n)
                I = L(G)
                Rg = L(R) - L(G)
                By = L(B) - (L(G) + L(R))/2 
                hue = atan2(Rg,By) * (180 / 3.141592654f)
             * 
             */
            Graphics g = Graphics.FromImage(originalImagePassed);
            ArrayList points = new ArrayList();
            for (int i = 0; i < originalImagePassed.Width; i++)
            {
                for (int j = 0; j < originalImagePassed.Height; j++)
                {
                    Color colorOfPixel_ij = modifiedImageWithSkin.GetPixel(i, j);
                    double I = (Math.Log(colorOfPixel_ij.R) + Math.Log(colorOfPixel_ij.G) + Math.Log(colorOfPixel_ij.B)) / 3;
                    double Rg = Math.Log(colorOfPixel_ij.R) - Math.Log(colorOfPixel_ij.G);
                    double By = Math.Log(colorOfPixel_ij.B) - (Math.Log(colorOfPixel_ij.G) + Math.Log(colorOfPixel_ij.R)) / 2;
                    double hue = Math.Atan2(Rg, By) * (180 / Math.PI);
                    // check if it is skin or not
                    if (I <= 5 && (hue >= 4 && hue <= 255))
                    {                        
                        points.Add(new Point(i, j));
                    }
                    else
                    {
                        // if this pixel is not a skin so paint it as Black
                        modifiedImageWithSkin.SetPixel(i, j, Color.Black);
                    }
                }
            }            
        }

        private static void drawLineFromNode1ToNode2(Graphics g, Point p1, Point p2)
        {
            g.DrawLine(Pens.White, p1, p2);
        }

        private static void SortPoints(ref ArrayList arrayOfPoints)
        {
            for (int i = 1; i < arrayOfPoints.Count; i++)
            {
                Point thisPoint = (Point)arrayOfPoints[i];
                Point lastPoint = (Point)arrayOfPoints[i - 1];
                if (thisPoint.X < lastPoint.X && thisPoint.Y < lastPoint.Y)
                {
                    
                }
                else
                {                    
                    swap(ref arrayOfPoints, i - 1, i);
                }
            }
        }

        private static void swap(ref ArrayList arrayOfPoints, int i, int j)
        {// a normal Swaping func
            Point temp;
            Point pointI = (Point)arrayOfPoints[i];
            Point PointJ = (Point)arrayOfPoints[j];

            temp = pointI;
            pointI = PointJ;
            PointJ = temp;
        }

        private static int maxOfRGB(int red, int green, int blue)
        {
            if (red > green && red > blue)
                return red;
            else if (green > red && green > blue)
                return green;
            else
                return blue;
        }

        private static int minOfRGB(int red, int green, int blue)
        {
            if (red < green && red < blue)
                return red;
            else if (green < red && green < blue)
                return green;
            else
                return blue;
        }               

        private void btnSkinDetection_Click(object sender, EventArgs e)
        {            
            //Bitmap original = new Bitmap(@"C:\Dara\Dropbox\CLASS\CS740\HW\HW07\baby.bmp");
            
            Bitmap imageForSkinRecognition = new Bitmap(originalImageFromPics);
            Bitmap modified = imageForSkinRecognition;
            DetectSkin(imageForSkinRecognition, ref modified);
            //pictureBox.Image = modified;
            finalImage = ScaleImage(modified, this.ClientRectangle.Width - pictureBox.Left - 3, this.ClientRectangle.Height - pictureBox.Top - 3);
            ImageWindow newWindow = new ImageWindow(finalImage, true);
            newWindow.Text = "Detected Faces and Skins";
            newWindow.Show();
        }

        public static Bitmap ScaleImage(Image imagePassed, int maxWidth, int maxHeight)
        {
            double ratioX = (double)maxWidth / imagePassed.Width;
            double ratioY = (double)maxHeight / imagePassed.Height;
            double ratio = Math.Min(ratioX, ratioY);
            int newWidth = (int)(imagePassed.Width * ratio);
            int newHeight = (int)(imagePassed.Height * ratio);
            Bitmap scaledImage = new Bitmap(newWidth, newHeight);
            Graphics.FromImage(scaledImage).DrawImage(imagePassed, 0, 0, newWidth, newHeight);
            return scaledImage;
        }

    }
}
