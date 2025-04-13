using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizzz.IRTUP.Classes
{
    public static class QuestionImageHelper
    {
        public static void InitializeImageHandling(PictureBox pictureBox,
                                            Button btnAddImage,
                                            Button btnRemoveImage,
                                            Action<byte[]> imageDataSetter)
        {
            btnAddImage.Click += (s, e) => AddImage(pictureBox, imageDataSetter);
            btnRemoveImage.Click += (s, e) => RemoveImage(pictureBox, imageDataSetter);
        }

        public static void AddImage(PictureBox pictureBox, Action<byte[]> imageDataSetter)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (Image image = Image.FromFile(openFileDialog.FileName))
                        {
                            byte[] imageData = ImageToBytes(image);
                            imageDataSetter?.Invoke(imageData);
                            pictureBox.Image = new Bitmap(image);
                            pictureBox.Visible = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error loading image: " + ex.Message);
                    }
                }
            }
        }

        public static byte[] GetImageBytes(Image image)
        {
            if (image == null) return null;

            using (MemoryStream ms = new MemoryStream())
            {
                // Save as JPEG to reduce size (can change to PNG if quality is important)
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                return ms.ToArray();
            }
        }



        public static void RemoveImage(PictureBox pictureBox, Action<byte[]> imageDataSetter)
        {
            imageDataSetter?.Invoke(null);
            pictureBox.Image = null;
            pictureBox.Visible = false;
        }

        public static void LoadImage(PictureBox pictureBox, byte[] imageData)
        {
            if (imageData != null && imageData.Length > 0)
            {
                try
                {
                    pictureBox.Image = BytesToImage(imageData);
                    pictureBox.Visible = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading image data: " + ex.Message);
                    pictureBox.Visible = false;
                }
            }
            else
            {
                pictureBox.Visible = false;
            }
        }

        public static byte[] ImageToBytes(Image image)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, image.RawFormat);
                return ms.ToArray();
            }
        }

        public static Image BytesToImage(byte[] bytes)
        {
            if (bytes == null || bytes.Length == 0) return null;

            using (MemoryStream ms = new MemoryStream(bytes))
            {
                try
                {
                    return Image.FromStream(ms);
                }
                catch
                {
                    return null;
                }
            }
        }
    }
}
