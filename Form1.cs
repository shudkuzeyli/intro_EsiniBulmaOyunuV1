using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace intro_EsiniBulmaOyunuV1
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}
		int[] dizi;
		Button birinciButon, ikinciButon;
		string btn1Text = "", btn2Text = "";

		private void Form1_Load(object sender, EventArgs e)
		{
			try
			{
				dizi = new int[16];

				Random rndSayi = new Random();
				int sayac = 0;
				while (sayac < 16)
				{
					int eklenecekSayi = rndSayi.Next(1, 17);
					if (Array.IndexOf(dizi, eklenecekSayi) == -1)
					{
						dizi[sayac] = eklenecekSayi;
						sayac++;
					}
				}

				for (int i = 0; i < dizi.Length; i++)
				{
					if (dizi[i] > 8)
						dizi[i] = dizi[i] - 8;
				}

				//dizi içindeki değerleri ekrandaki butonların tag değerine atayacağız.
				//ekrandaki butonları döngü içinde kullanarak, tag değerlerini değiştireceğiz.
				//Foreach -> nesne içinde dönmek için kullanırız.
				//primitive: int, floot, decimal vb. değer saklar.
				//object: nesne, içinde property saklayan yapılar değerler içerir. 
				//var: tür bağımsız değer saklayan.
				//interface: değişken türünün otomatik olarak oluşturulan yapısına denir. 

				sayac = 0;
				foreach (Control item in panel1.Controls)
				{
					//item ı bir buton olduğuna ikna ediyoruz. :)
					if (item is Button)
					{
						((Button)item).Tag = dizi[sayac].ToString();
						sayac++;
					}
				}

			}
			catch (Exception hata)
			{
				MessageBox.Show(hata.Message);
			}
		}

		void ButonaTiklandi(object sender, EventArgs e)
		{
			//fonksiyon oluşturduk.
			//sender -> bu fonksiyonu çağıran buton
			//object türdeki bir değeri kullanmak için nesneye box'lamamız lazım
			Button btn = sender as Button;
			if (btn1Text != "" && btn2Text != "")
			{
				//demekki iki kere butona basmışız. şimdi bu iki butonun tag larını karşılaştıralım.
				birinciButon.Text = "*";
				ikinciButon.Text = "*";

				birinciButon.Enabled = true;
				ikinciButon.Enabled = true;

				btn1Text = "";
				btn2Text = "";
			}

			if (btn1Text == "")
				BirinciButonaBasildi(btn);
			else
				IkinciButonaBasildi(btn);

		}

		private void btnBasla_Click(object sender, EventArgs e)
		{
			foreach (Control item in panel1.Controls)
			{
				((Button)item).Enabled = true;
				((Button)item).Text = "*";
			}

			//başka bşr fonksiyonu çağırma işlemi
			Form1_Load(null, null);
		}

		private void BirinciButonaBasildi(Button btn)
		{
			birinciButon = btn;
			btn1Text = btn.Tag.ToString();
			btn.Enabled = false;
			btn.Text = btn1Text;
		}

		private void IkinciButonaBasildi(Button btn)
		{
			ikinciButon = btn;
			btn2Text = btn.Tag.ToString();
			if (btn1Text == btn2Text)
			{
				btn.Text = btn2Text;
				btn1Text = "";
				btn2Text = "";
			}
			else
			{
				btn.Text = btn2Text;
			}

			btn.Enabled = false;
		}

	}
}
