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
        private void EncryptFile(byte[] key)
        {
            StreamReader inputFile;
            byte[] text;
            if(openFile.ShowDialog() == DialogResult.OK)
            {
                byte[] IV = Encoding.ASCII.GetBytes("abcdefghabcdefgh");
                inputFile = File.OpenText(openFile.FileName);
                string fileName = openFile.FileName;
                
            
                text = Encoding.ASCII.GetBytes(inputFile.ReadToEnd());
                inputFile.Close();
                SymmetricAlgorithm aesCSP = new AesCryptoServiceProvider();
                aesCSP.BlockSize = 128;
                aesCSP.KeySize = 256;
                aesCSP.Key = key;
                aesCSP.IV = IV;
                aesCSP.Padding = PaddingMode.PKCS7;
                aesCSP.Mode = CipherMode.CFB;
                ICryptoTransform encryptor = aesCSP.CreateEncryptor(aesCSP.Key, aesCSP.IV);
                byte[] encrypted = encryptor.TransformFinalBlock(text, 0, text.Length);

                StreamWriter outputFile;
                outputFile = File.CreateText(fileName);
                outputFile.Write(Encoding.ASCII.GetString(encrypted));
                outputFile.Close();
            }
        }

        // funksie om textfile te dekripteer
        private void DecryptFile(byte[] key)
        {
            StreamReader inputFile;
            byte[] text;
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                byte[] IV = Encoding.ASCII.GetBytes("abcdefghabcdefgh");
                inputFile = File.OpenText(openFile.FileName);
                string fileName = openFile.FileName;
                string plaintext = inputFile.ReadToEnd();

                text = Encoding.ASCII.GetBytes(plaintext);
                MessageBox.Show(Encoding.ASCII.GetString(text));
                inputFile.Close();
                SymmetricAlgorithm aesCSP = new AesCryptoServiceProvider();
                aesCSP.BlockSize = 128;
                aesCSP.KeySize = 256;
                aesCSP.Key = key;
                aesCSP.IV = IV;
                aesCSP.Padding = PaddingMode.PKCS7;
                aesCSP.Mode = CipherMode.CFB;
                ICryptoTransform decryptor = aesCSP.CreateDecryptor(aesCSP.Key, aesCSP.IV);

                byte[] decrypted = decryptor.TransformFinalBlock(text, 0, text.Length);
                decryptor.Dispose();

                StreamWriter outputFile;
                outputFile = File.CreateText(fileName);
                outputFile.Write(Encoding.ASCII.GetString(decrypted));
                outputFile.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
             
            byte[] key = Encoding.ASCII.GetBytes(txtKey.Text.ToArray()) ;

            if (rbTXT.Checked && rbEncrypt.Checked)
            {
                EncryptFile(key);
            }
            else if(rbTXT.Checked && rbDecrypt.Checked)
            {
                DecryptFile(key);
            }
            
        }

        private void rbTXT_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void rbPhoto_CheckedChanged(object sender, EventArgs e)
        {
           
        }
    }
}
