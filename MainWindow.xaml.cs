using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SymmetriskKryptering
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }



        //Decrypt button
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //Decrypt button to decrypt the hex message with the key and IV from the text boxes
            Stopwatch sw = new Stopwatch();
            sw.Start();

            if (cbi.SelectedIndex == 0)
            {   // Decrypt DES encryption 

                // Create new DES instantiation
                var des = new DesEncryption();

                // key and iv converted to byte arrays to be used in the Decrypt method below
                byte[] key = Convert.FromBase64String(key_box.Text);
                byte[] iv = Convert.FromBase64String(IV_box.Text);

                // Decryption method takes in the encrypted hexidecimal-text from the textbox and the key/iv byte arrays
                var decryptedText = des.Decrypt(Convert.FromBase64String(hex_decrypt.Text), key, iv);

                // send the decrypted text to ASCI text box in View
                Chiphertext.Text = Encoding.UTF8.GetString(decryptedText);

            }
            else if (cbi.SelectedIndex == 1)
            {   // Decrypt TripleDES encryption

                // Create new TripleDES instantiation
                var tdes = new TDESEncryption();

                // key and iv converted to byte arrays to be used in the Decrypt method below
                byte[] key = Convert.FromBase64String(key_box.Text);
                byte[] iv = Convert.FromBase64String(IV_box.Text);

                // Decryption method takes in the encrypted hexidecimal-text from the textbox and the key/iv byte arrays
                var decryptedText = tdes.Decrypt(Convert.FromBase64String(hex_decrypt.Text), key, iv);

                // send the decrypted text to ASCI text box in View
                Chiphertext.Text = Encoding.UTF8.GetString(decryptedText);

            }
            else if (cbi.SelectedIndex == 2)
            {   // Decrypt AES encryption
                
                // Create new AES instantiation
                var aes = new AESEncryption();

                // key and iv converted to byte arrays to be used in the Decrypt method below
                byte[] key = Convert.FromBase64String(key_box.Text);
                byte[] iv = Convert.FromBase64String(IV_box.Text);

                // Decryption method takes in the encrypted hexidecimal-text from the textbox and the key/iv byte arrays
                var decryptedText = aes.Decrypt(Convert.FromBase64String(hex_decrypt.Text), key, iv);

                // send the decrypted text to ASCI text box in View
                Chiphertext.Text = Encoding.UTF8.GetString(decryptedText);

            }
            //Stops the Stopwatch and saves the times used to encrypt/decrypt the message.
            sw.Stop();
            TimeSpan time2 = sw.Elapsed;

            //Display the saved time in miliseconds 
            DecryptTextBlock.Text = time2.TotalMilliseconds.ToString() + "ms";
        }

        //Generate Key and IV button
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // generate a key and IV and show them in the text boxes: "key_box" and "IV_box"
            
            if (cbi.SelectedIndex == 0)
            {   // DES key/IV generator

                // Create new DES instantiation
                var des = new DesEncryption();

                // Generate DES Key and IV
                var key = des.GenerateRandomNumber(8);
                var iv = des.GenerateRandomNumber(8);

                // Send the generated keys to the View text boxes as strings
                key_box.Text = Convert.ToBase64String(key);
                IV_box.Text = Convert.ToBase64String(iv);

            }
            else if (cbi.SelectedIndex == 1)
            {   // TripleDES key/IV Generator

                // Create new TripleDES instantiation
                var des = new TDESEncryption();

                // Generate TripleDES Key and IV
                var key = des.GenerateRandomNumber(16);
                var iv = des.GenerateRandomNumber(8);

                // Send the generated keys to the View text boxes as strings
                key_box.Text = Convert.ToBase64String(key);
                IV_box.Text = Convert.ToBase64String(iv);

            }
            else if (cbi.SelectedIndex == 2)
            {   // AES key/IV generator

                // Create new AES instantiation
                var des = new AESEncryption();

                // Generate AES Key and IV
                var key = des.GenerateRandomNumber(32);
                var iv = des.GenerateRandomNumber(16);

                // Send the generated keys to the View text boxes as strings
                key_box.Text = Convert.ToBase64String(key);
                IV_box.Text = Convert.ToBase64String(iv);

            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void key_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void hmacTxt_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ListBoxItem_Selected(object sender, RoutedEventArgs e)
        {

        }

        // Encrypt button
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            //Encrypt button to encrypt the plaintext message with the keys generated 

            Stopwatch sw = new Stopwatch();
            sw.Start();

            if (cbi.SelectedIndex == 0)
            {   
                // Decryption DES

                // Create new DES instantiation
                var des = new DesEncryption();

                // Get key/IV strings from the View text boxes and convert them to byte arrays 
                byte[] key = Convert.FromBase64String(key_box.Text);
                byte[] iv = Convert.FromBase64String(IV_box.Text);

                // Copy the text string from the plaintext box in a string variable for the encryption method 
                string plaintext = Plaintext.Text;

                // Encrypt the plaintext method with the plaintext, key and iv.
                var encryptedText = des.Encrypt(Encoding.UTF8.GetBytes(plaintext), key, iv);

                // send the encrypted text message to the encrypted hex box and decrypted hex box
                hex_encrypt.Text = Convert.ToBase64String(encryptedText);
                hex_decrypt.Text = Convert.ToBase64String(encryptedText);
            }
            else if (cbi.SelectedIndex == 1)
            {
                // Decryption TripleDES

                // Create new TripleDES instantiation
                var des = new TDESEncryption();

                // Get key/IV strings from the View text boxes and convert them to byte arrays 
                byte[] key = Convert.FromBase64String(key_box.Text);
                byte[] iv = Convert.FromBase64String(IV_box.Text);

                // Copy the text string from the plaintext box in a string variable for the encryption method 
                string plaintext = Plaintext.Text;

                // Encrypt the plaintext method with the plaintext, key and iv.
                var encryptedText = des.Encrypt(Encoding.UTF8.GetBytes(plaintext), key, iv);

                // send the encrypted text message to the encrypted hex box and decrypted hex box
                hex_encrypt.Text = Convert.ToBase64String(encryptedText);
                hex_decrypt.Text = Convert.ToBase64String(encryptedText);
            }
            else if (cbi.SelectedIndex == 2)
            {
                // Decryption AES

                // Create new AES instantiation
                var des = new AESEncryption();

                // Get key/IV strings from the View text boxes and convert them to byte arrays 
                byte[] key = Convert.FromBase64String(key_box.Text);
                byte[] iv = Convert.FromBase64String(IV_box.Text);

                // Copy the text string from the plaintext box in a string variable for the encryption method 
                string plaintext = Plaintext.Text;

                // Encrypt the plaintext method with the plaintext, key and iv.
                var encryptedText = des.Encrypt(Encoding.UTF8.GetBytes(plaintext), key, iv);

                // send the encrypted text message to the encrypted hex box and decrypted hex box
                hex_encrypt.Text = Convert.ToBase64String(encryptedText);
                hex_decrypt.Text = Convert.ToBase64String(encryptedText);
            }
            sw.Stop();
            TimeSpan time1 = sw.Elapsed;
            EncryptTextBlock.Text = time1.TotalMilliseconds.ToString() + "ms";
        }
    }
}
