using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace AdamAsmaca
{
    public partial class Form1 : Form
    {
        private string[] iller;
        private string secilenIl;
        private char[] tahminEdilen;
        private int kalanHak = 9; // Hata hakkı 9 olarak ayarlandı
        private char[] harfler;

        public Form1()
        {
            InitializeComponent();
            LoadIller();
            StartNewGame();
        }

        private void LoadIller()
        {
            try
            {
                string dosyaYolu = "iller.txt"; // iller.txt dosyasının yolu
                if (!File.Exists(dosyaYolu))
                {
                    MessageBox.Show("iller.txt dosyası bulunamadı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
                iller = File.ReadAllLines(dosyaYolu);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Dosya okunurken hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void StartNewGame()
        {
            Random random = new Random();
            secilenIl = iller[random.Next(iller.Length)].ToUpper();
            tahminEdilen = new string('_', secilenIl.Length).ToCharArray();
            kalanHak = 7; // Yeni oyun başladığında hata hakkı 9
            harfler = new char[0];

            // Her harf arasında boşluk bırakmak için kelimeyi ayır
            lblWord.Text = string.Join(" ", tahminEdilen);
            lblRemaining.Text = $"Kalan Hak: {kalanHak}";
            flpHarfler.Controls.Clear();

            // Türk alfabesindeki harfleri ekle
            string[] turkceHarfler = { "A", "B", "C", "Ç", "D", "E", "F", "G", "Ğ", "H", "I", "İ", "J", "K", "L", "M", "N", "O", "Ö", "P", "R", "S", "Ş", "T", "U", "Ü", "V", "Y", "Z" };
            foreach (string harf in turkceHarfler)
            {
                Button btn = new Button();
                btn.Text = harf;
                btn.Click += HarfButonu_Click;
                btn.Size = new Size(40, 40);
                btn.BackColor = Color.LightBlue; // Renk ayarı
                flpHarfler.Controls.Add(btn);
            }
        }

        private void HarfButonu_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                btn.Enabled = false; // Butonu devre dışı bırak
                btn.BackColor = Color.LightGray; // Buton rengini değiştir
                char tahmin = char.ToUpper(btn.Text[0]);
                TahminEt(tahmin);
            }
        }

        private void TahminEt(char tahmin)
        {
            if (harfler.Contains(tahmin) || tahminEdilen.Contains(tahmin))
            {
                MessageBox.Show("Bu harfi zaten tahmin ettiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            harfler = harfler.Append(tahmin).ToArray();

            if (secilenIl.Contains(tahmin))
            {
                for (int i = 0; i < secilenIl.Length; i++)
                {
                    if (secilenIl[i] == tahmin)
                    {
                        tahminEdilen[i] = tahmin;
                    }
                }

                // Kelimenin gösteriminde her harf arasında boşluk bırak
                lblWord.Text = string.Join(" ", tahminEdilen);

                if (!tahminEdilen.Contains('_'))
                {
                    MessageBox.Show($"Tebrikler! Doğru cevap: {secilenIl}", "Kazandınız", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    StartNewGame();
                }
            }
            else
            {
                kalanHak--;
                lblRemaining.Text = $"Kalan Hak: {kalanHak}";
                Invalidate(); // Yeniden çizim yap
                if (kalanHak == 0)
                {
                    MessageBox.Show($"Oyunu kaybettiniz! Doğru cevap: {secilenIl}", "Kaybettiniz", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    StartNewGame();
                }
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            DrawHangman(e.Graphics); // Adam asma durumunu çiz
        }

        private void DrawHangman(Graphics g)
        {
            int xOffset = 500; // Çizim için x konumunu ayarla (en sağa konumlandırma)
            int yBase = 300; // Y konumunu ayarla

            // Darağacı
            g.DrawLine(Pens.Black, xOffset, yBase, xOffset, 50); // Dikey direk
            g.DrawLine(Pens.Black, xOffset, 50, xOffset + 100, 50); // Üst çubuk
            g.DrawLine(Pens.Black, xOffset + 100, 50, xOffset + 100, 80); // İp

            // Kalan haklara göre adamın tüm parçalarını önceki haklardan başlayarak çiz
            if (kalanHak <= 6)
            {
                g.DrawEllipse(Pens.Black, xOffset + 90, 80, 30, 30); // Baş
            }
            if (kalanHak <= 5)
            {
                g.DrawLine(Pens.Black, xOffset + 105, 110, xOffset + 105, 180); // Gövde
            }
            if (kalanHak <= 4)
            {
                g.DrawLine(Pens.Black, xOffset + 105, 120, xOffset + 80, 150); // Sol kol
                g.DrawLine(Pens.Black, xOffset + 105, 120, xOffset + 130, 150); // Sağ kol
            }
            if (kalanHak <= 3)
            {
                g.DrawLine(Pens.Black, xOffset + 105, 180, xOffset + 80, 210); // Sol bacak
                g.DrawLine(Pens.Black, xOffset + 105, 180, xOffset + 130, 210); // Sağ bacak
            }
            if (kalanHak <= 2)
            {
                // Gözler için 'X' işaretleri
                g.DrawLine(Pens.Black, xOffset + 95, 90, xOffset + 105, 100); // Sol göz 'X' çarpı
                g.DrawLine(Pens.Black, xOffset + 105, 90, xOffset + 95, 100);
                g.DrawLine(Pens.Black, xOffset + 115, 90, xOffset + 125, 100); // Sağ göz 'X' çarpı
                g.DrawLine(Pens.Black, xOffset + 125, 90, xOffset + 115, 100);
            }
            if (kalanHak <= 1)
            {
                g.DrawLine(Pens.Black, xOffset + 95, 110, xOffset + 125, 110); // Ağız
            }
        }

        private void btnNewGame_Click(object sender, EventArgs e)
        {
            StartNewGame(); // Yeni oyun başlat
        }
    }
}
