using System;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace mod8_kel32
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
			InitializeComboBox();
		}

		private void InitializeComboBox()
		{
			comboBoxFrom.Items.AddRange(new string[] { "Celcius", "Reamur", "Fahrenheit", "Kelvin" });
			comboBoxTo.Items.AddRange(new string[] { "Celcius", "Reamur", "Fahrenheit", "Kelvin" });
			comboBoxFrom.SelectedIndex = 0;
			comboBoxTo.SelectedIndex = 0;
		}

		private void btnConvert_Click(object sender, EventArgs e)
		{
			if (double.TryParse(txtInput.Text, out double inputValue))
			{
				double result = 0;

				switch (comboBoxFrom.SelectedItem.ToString())
				{
					case "Celcius":
						result = ConvertCelcius(inputValue, comboBoxTo.SelectedItem.ToString());
						break;
					case "Reamur":
						result = ConvertReamur(inputValue, comboBoxTo.SelectedItem.ToString());
						break;
					case "Fahrenheit":
						result = ConvertFahrenheit(inputValue, comboBoxTo.SelectedItem.ToString());
						break;
					case "Kelvin":
						result = ConvertKelvin(inputValue, comboBoxTo.SelectedItem.ToString());
						break;
					default:
						break;
				}

				lblResult.Text = $"{inputValue} {comboBoxFrom.SelectedItem} = {result} {comboBoxTo.SelectedItem}";
			}
			else
			{
				MessageBox.Show("Masukkan nilai suhu yang valid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private double ConvertCelcius(double value, string toUnit)
		{
			switch (toUnit)
			{
				case "Celcius":
					return value;
				case "Reamur":
					return value * 0.8;
				case "Fahrenheit":
					return (value * 9 / 5) + 32;
				case "Kelvin":
					return value + 273.15;
				default:
					return 0;
			}
		}

		private double ConvertReamur(double value, string toUnit)
		{
			switch (toUnit)
			{
				case "Celcius":
					return value / 0.8;
				case "Reamur":
					return value;
				case "Fahrenheit":
					return (value * 9 / 4) + 32;
				case "Kelvin":
					return (value / 0.8) + 273.15;
				default:
					return 0;
			}
		}

		private double ConvertFahrenheit(double value, string toUnit)
		{
			switch (toUnit)
			{
				case "Celcius":
					return (value - 32) * 5 / 9;
				case "Reamur":
					return (value - 32) * 4 / 9;
				case "Fahrenheit":
					return value;
				case "Kelvin":
					return (value - 32) * 5 / 9 + 273.15;
				default:
					return 0;
			}
		}

		private double ConvertKelvin(double value, string toUnit)
		{
			switch (toUnit)
			{
				case "Celcius":
					return value - 273.15;
				case "Reamur":
					return (value - 273.15) * 0.8;
				case "Fahrenheit":
					return (value - 273.15) * 9 / 5 + 32;
				case "Kelvin":
					return value;
				default:
					return 0;
			}
		}
	}
}
