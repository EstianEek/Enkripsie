using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography;

namespace Encryption
{
    public partial class Encrypt : Form
    {
        byte[] fileKey;
        byte[] fileIV;
        byte[] imgKey;
        byte[] imgIV;
        public Encrypt()
        {
            InitializeComponent();
        }

        public byte[] ImageToByte(System.Drawing.Image image)
        {
            using (var ms = new MemoryStream())
            {
                image.Save(ms, image.RawFormat);
                return ms.ToArray();
            }
        }

        public Image ByteToImage(byte[] byteArray)
        {
            MemoryStream ms = new MemoryStream(byteArray);    
            
            return Image.FromStream(ms);

        }
        // funksie om foto te enkripteer
        private void EncryptPicture(byte[] key, byte[] IV)
        {
            if (key == null || key.Length <= 0)
            {
                throw new ArgumentNullException("Key");
            }
            if (IV == null || IV.Length <= 0)
            {
                throw new ArgumentNullException("IV");
            }

            try
            {
                Image newImage;
                Image encryptedImage;

                

                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    newImage = Image.FromFile(openFile.FileName);
                    string fileName = openFile.FileName;
                    MessageBox.Show(fileName);

                    byte[] image = ImageToByte(newImage);
                    MessageBox.Show(Encoding.Default.GetString(image.ToArray()));

                    using (Aes aesAlg = Aes.Create())
                    {
                        aesAlg.Key = key;
                        aesAlg.IV = IV;

                        ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                        using (MemoryStream msEncrypt = new MemoryStream())
                        {
                            using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                            {
                                using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                                {
                                    swEncrypt.Write(image);
                                    MessageBox.Show("Yes");
                                    
                                }
                                MessageBox.Show(Encoding.Default.GetString(image.ToArray()));
                                encryptedImage = ByteToImage(msEncrypt.ToArray());
                                MessageBox.Show("Test");
                                
                                try
                                {
                                    if (encryptedImage != null)
                                    {
                                        encryptedImage.Save(fileName);
                                        MessageBox.Show("Image encrypted");
                                    }
                                }
                                catch (Exception)
                                {
                                    MessageBox.Show("There was a problem saving the file." +
                                        "Check the file permissions.");
                                }


                            }

                            
                        }
                    }

                    MessageBox.Show("Encryption Done");

                }
                else
                {
                    MessageBox.Show("Cannot open file");
                }


            }
            catch
            {
                MessageBox.Show("Operation canceled");
            }
        }


        // funksie om textfile te enkripteer
        private void EncryptFile(byte[] key, byte[] IV)
        {
            MessageBox.Show(fileKey + " " + fileIV);

            if (key == null || key.Length <= 0)
            {
                throw new ArgumentNullException("Key");
            }
            if(IV == null || IV.Length <= 0)
            {
                throw new ArgumentNullException("IV");
            }

            

            try
            {
                StreamReader inputFile;
                
                openFile.ShowDialog();

                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    inputFile = File.OpenText(openFile.FileName);
                    string fileName = openFile.FileName;

                    string text = inputFile.ReadToEnd();

                    inputFile.Close();

                    MessageBox.Show(text);

                    using (Aes aesAlg = Aes.Create())
                    {
                        aesAlg.Key = key;
                        aesAlg.IV = IV;

                        ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                        using (MemoryStream msEncrypt = new MemoryStream())
                        {
                            using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                            {
                                using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                                {
                                    swEncrypt.Write(text);
                                }
                                
                                
                                StreamWriter outputFile;
                                outputFile = File.CreateText(fileName);
                                outputFile.Write(Encoding.Default.GetString(msEncrypt.ToArray()));
                                outputFile.Close();
                            }
                        }
                    }

                    MessageBox.Show("Encryption Done");

                }
                else
                {
                    MessageBox.Show("Cannot open file");
                }

               
            }
            catch
            {
                MessageBox.Show("Operation canceled");
            }

            
        }


        // funksie om textfile te dekripteer
        private void DecryptFile(byte[] key, byte[] IV)
        {
            MessageBox.Show(fileKey + " " + fileIV);
            if (key == null || key.Length <= 0)
            {
                throw new ArgumentNullException("Key");
            }
            if (IV == null || IV.Length <= 0)
            {
                throw new ArgumentNullException("IV");
            }

            try
            {
                StreamReader inputFile;

                openFile.ShowDialog();

                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    inputFile = File.OpenText(openFile.FileName);
                    string fileName = openFile.FileName;
                    MessageBox.Show(fileName);

                    string text = inputFile.ReadToEnd();

                    inputFile.Close();

                    MessageBox.Show(text);

                    byte[] cipher = Encoding.ASCII.GetBytes(text);
                    MessageBox.Show(Encoding.Default.GetString(cipher.ToArray()));

                    using (Aes aesAlg = Aes.Create())
                    {
                        aesAlg.Key = key;
                        aesAlg.IV = IV;

                        ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                        using (MemoryStream msDecrypt = new MemoryStream(cipher))
                        {
                            using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                            {
                                using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                                {
                                    text = srDecrypt.ReadToEnd();
                                    MessageBox.Show(text);
                                    
                                }
                                StreamWriter outputFile;
                                MessageBox.Show("Test");
                                outputFile = File.CreateText(fileName);

                                outputFile.Write(text);

                                outputFile.Close();
                            }
                        }
                    }
                }
            }           
            catch
            {
                MessageBox.Show("Operation cancelled");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        { 
            if(rbPhoto.Checked)
            {
                if(rbEncrypt.Checked)
                {
                    EncryptPicture(imgKey, imgIV);
                }
            }

            else if(rbTXT.Checked)
            {
                if (rbEncrypt.Checked)
                {
                    EncryptFile(fileKey, fileIV);
                }
                else if (rbDecrypt.Checked)
                {
                    DecryptFile(fileKey, fileIV);
                }
            }
            
        }

        private void rbTXT_CheckedChanged(object sender, EventArgs e)
        {
            using (Aes myAes = Aes.Create())
            {

                fileKey = myAes.Key;
                fileIV = myAes.IV;

            }
        }

        private void rbPhoto_CheckedChanged(object sender, EventArgs e)
        {
            using (Aes myAes = Aes.Create())
            {

                imgKey = myAes.Key;
                imgIV = myAes.IV;

            }
        }
    }
}
