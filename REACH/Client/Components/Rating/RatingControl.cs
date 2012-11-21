using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Rating
{
	public partial class RatingControl : UserControl
	{
		public const int MAX_RATING = 5;

		private int old_rating;
		private int rating = 0;
		private PictureBox[] img;
		private Boolean fixedRating = false;

		public delegate void SelectRatingHandler(object sender, int rating);
		public event SelectRatingHandler SelectRating;

		public RatingControl()
		{
			InitializeComponent();
			img = new PictureBox[5] { 
				img1_off, img2_off, img3_off, img4_off, img5_off };
			Rating = rating;
			old_rating = rating;
		}

		private void displayStars(int nrStars)
		{
			for (int i = 0; i < MAX_RATING; ++i)
				img[i].Visible = false;
			for (int i = nrStars; i < MAX_RATING; ++i)
				img[i].Visible = true;
		}

		public Boolean Fixed
		{
			set
			{
				fixedRating = value;
			}
			get
			{
				return fixedRating;
			}
		}

		public int Rating
		{
			set
			{
				if (value < 0 || value > MAX_RATING)
					throw new Exception("The rating must be between 0 and " + MAX_RATING);
				old_rating = rating;
				rating = value;
				displayStars(rating);
			}
			get
			{
				return rating;
			}
		}

		protected virtual void OnSelectRating(int rating)
		{
			if (SelectRating != null && !fixedRating)
			{
				this.Rating = rating;
				SelectRating(this, rating);
			}
		}

		private void img1_off_MouseEnter(object sender, EventArgs e)
		{
			if (!fixedRating)
				displayStars(1);
		}

		private void img2_off_MouseEnter(object sender, EventArgs e)
		{
			if (!fixedRating)
				displayStars(2);
		}

		private void img3_off_MouseEnter(object sender, EventArgs e)
		{
			if (!fixedRating)
				displayStars(3);
		}

		private void img4_off_MouseEnter(object sender, EventArgs e)
		{
			if (!fixedRating)
				displayStars(4);
		}

		private void img5_off_MouseEnter(object sender, EventArgs e)
		{
			if (!fixedRating)
				displayStars(5);
		}

		private void img1_on_MouseEnter(object sender, EventArgs e)
		{
			if (!fixedRating)
				displayStars(1);
		}

		private void img2_on_MouseEnter(object sender, EventArgs e)
		{
			if (!fixedRating)
				displayStars(2);
		}

		private void img3_on_MouseEnter(object sender, EventArgs e)
		{
			if (!fixedRating)
				displayStars(3);
		}

		private void img4_on_MouseEnter(object sender, EventArgs e)
		{
			if (!fixedRating)
				displayStars(4);
		}

		private void img5_on_MouseEnter(object sender, EventArgs e)
		{
			if (!fixedRating)
				displayStars(5);
		}

		private void img1_on_Click(object sender, EventArgs e)
		{
			OnSelectRating(1);
		}

		private void img2_on_Click(object sender, EventArgs e)
		{
			OnSelectRating(2);
		}

		private void img3_on_Click(object sender, EventArgs e)
		{
			OnSelectRating(3);
		}

		private void img4_on_Click(object sender, EventArgs e)
		{
			OnSelectRating(4);
		}

		private void img5_on_Click(object sender, EventArgs e)
		{
			OnSelectRating(5);
		}

		private void RatingControl_MouseEnter(object sender, EventArgs e)
		{
			Rating = old_rating;
		}

	}
}
