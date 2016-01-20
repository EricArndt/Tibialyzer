﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing.Drawing2D;
using System.Diagnostics;


namespace Tibialyzer {
    class ItemViewForm : NotificationForm {
        private Label itemName;
        private Label itemCategory;
        private Label lookText;
        private System.Windows.Forms.PictureBox itemPictureBox;

        public Item item;
        public Dictionary<NPC, int> buyNPCs = null;
        public Dictionary<NPC, int> sellNPCs = null;
        private System.Windows.Forms.CheckBox pickupBox;
        private System.Windows.Forms.CheckBox convertBox;
        public Dictionary<Creature, float> creatures = null;
        private Label statsButton;
        private PictureBox increaseValue1;
        private PictureBox decreaseValue1;
        private Label valueDigit1;
        private Label valueDigit10;
        private PictureBox decreaseValue10;
        private PictureBox increaseValue10;
        private Label valueDigit100;
        private PictureBox decreaseValue100;
        private PictureBox increaseValue100;
        private Label valueDigit1000;
        private PictureBox decreaseValue1000;
        private PictureBox increaseValue1000;
        private Label valueDigit10000;
        private PictureBox decreaseValue10000;
        private PictureBox increaseValue10000;
        private Label valueDigit100000;
        private PictureBox decreaseValue100000;
        private PictureBox increaseValue100000;
        private Label valueDigit1000000;
        private PictureBox decreaseValue1000000;
        private PictureBox increaseValue1000000;
        private Label valueDigit10000000;
        private PictureBox decreaseValue10000000;
        private PictureBox increaseValue10000000;
        private Label valueDigit100000000;
        private PictureBox decreaseValue100000000;
        private PictureBox increaseValue100000000;
        private Label valueDigit1000000000;
        private PictureBox decreaseValue1000000000;
        private PictureBox increaseValue1000000000;
        private Label valueDigit10000000000;
        private PictureBox decreaseValue10000000000;
        private PictureBox increaseValue10000000000;
        private string previous_value;

        private List<PictureBox> increaseBoxes = new List<PictureBox>();
        private List<PictureBox> decreaseBoxes = new List<PictureBox>();
        private List<Label> valueLabels = new List<Label>();

        public ItemViewForm() {
            skip_event = true;
            InitializeComponent();
            skip_event = false;

            valueLabels.Add(valueDigit1);
            valueLabels.Add(valueDigit10);
            valueLabels.Add(valueDigit100);
            valueLabels.Add(valueDigit1000);
            valueLabels.Add(valueDigit10000);
            valueLabels.Add(valueDigit100000);
            valueLabels.Add(valueDigit1000000);
            valueLabels.Add(valueDigit10000000);
            valueLabels.Add(valueDigit100000000);
            valueLabels.Add(valueDigit1000000000);
            valueLabels.Add(valueDigit10000000000);
            decreaseBoxes.Add(decreaseValue1);
            decreaseBoxes.Add(decreaseValue10);
            decreaseBoxes.Add(decreaseValue100);
            decreaseBoxes.Add(decreaseValue1000);
            decreaseBoxes.Add(decreaseValue10000);
            decreaseBoxes.Add(decreaseValue100000);
            decreaseBoxes.Add(decreaseValue1000000);
            decreaseBoxes.Add(decreaseValue10000000);
            decreaseBoxes.Add(decreaseValue100000000);
            decreaseBoxes.Add(decreaseValue1000000000);
            decreaseBoxes.Add(decreaseValue10000000000);
            increaseBoxes.Add(increaseValue1);
            increaseBoxes.Add(increaseValue10);
            increaseBoxes.Add(increaseValue100);
            increaseBoxes.Add(increaseValue1000);
            increaseBoxes.Add(increaseValue10000);
            increaseBoxes.Add(increaseValue100000);
            increaseBoxes.Add(increaseValue1000000);
            increaseBoxes.Add(increaseValue10000000);
            increaseBoxes.Add(increaseValue100000000);
            increaseBoxes.Add(increaseValue1000000000);
            increaseBoxes.Add(increaseValue10000000000);

            for (int i = 0; i < decreaseBoxes.Count; i++) {
                PictureBox box = decreaseBoxes[i];
                box.Image = MainForm.mapdown_image;
                box.Name = (-Math.Pow(10, i)).ToString();
                box.Click += changeClick;
            }

            for (int i = 0; i < increaseBoxes.Count; i++) {
                PictureBox box = increaseBoxes[i];
                box.Image = MainForm.mapup_image;
                box.Name = (Math.Pow(10, i)).ToString();
                box.Click += changeClick;
            }
        }

        private void updateValue() {
            long value = Math.Max(item.actual_value, 0);
            for (int i = 0; i < valueLabels.Count; i++) {
                long next = value / 10;
                long remainder = value - (next * 10);

                if (next == 0 && remainder == 0 && i > 0) {
                    valueLabels[i].Visible = false;
                } else {
                    valueLabels[i].Text = remainder.ToString();
                    valueLabels[i].Visible = true;
                }

                value = next;
            }
        }

        private void changeClick(object sender, EventArgs e) {
            long change = long.Parse((sender as Control).Name);
            long modifiedValue = Math.Max(Math.Max(item.actual_value, 0) + change, 0);
            MainForm.mainForm.ExecuteCommand("setval" + MainForm.commandSymbol + item.GetName() + "=" + modifiedValue);
            updateValue();
        }

        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ItemViewForm));
            this.valueDigit10000000000 = new System.Windows.Forms.Label();
            this.decreaseValue10000000000 = new System.Windows.Forms.PictureBox();
            this.increaseValue10000000000 = new System.Windows.Forms.PictureBox();
            this.valueDigit1000000000 = new System.Windows.Forms.Label();
            this.decreaseValue1000000000 = new System.Windows.Forms.PictureBox();
            this.increaseValue1000000000 = new System.Windows.Forms.PictureBox();
            this.valueDigit100000000 = new System.Windows.Forms.Label();
            this.decreaseValue100000000 = new System.Windows.Forms.PictureBox();
            this.increaseValue100000000 = new System.Windows.Forms.PictureBox();
            this.valueDigit10000000 = new System.Windows.Forms.Label();
            this.decreaseValue10000000 = new System.Windows.Forms.PictureBox();
            this.increaseValue10000000 = new System.Windows.Forms.PictureBox();
            this.valueDigit1000000 = new System.Windows.Forms.Label();
            this.decreaseValue1000000 = new System.Windows.Forms.PictureBox();
            this.increaseValue1000000 = new System.Windows.Forms.PictureBox();
            this.valueDigit100000 = new System.Windows.Forms.Label();
            this.decreaseValue100000 = new System.Windows.Forms.PictureBox();
            this.increaseValue100000 = new System.Windows.Forms.PictureBox();
            this.valueDigit10000 = new System.Windows.Forms.Label();
            this.decreaseValue10000 = new System.Windows.Forms.PictureBox();
            this.increaseValue10000 = new System.Windows.Forms.PictureBox();
            this.valueDigit1000 = new System.Windows.Forms.Label();
            this.decreaseValue1000 = new System.Windows.Forms.PictureBox();
            this.increaseValue1000 = new System.Windows.Forms.PictureBox();
            this.valueDigit100 = new System.Windows.Forms.Label();
            this.decreaseValue100 = new System.Windows.Forms.PictureBox();
            this.increaseValue100 = new System.Windows.Forms.PictureBox();
            this.valueDigit10 = new System.Windows.Forms.Label();
            this.decreaseValue10 = new System.Windows.Forms.PictureBox();
            this.increaseValue10 = new System.Windows.Forms.PictureBox();
            this.valueDigit1 = new System.Windows.Forms.Label();
            this.decreaseValue1 = new System.Windows.Forms.PictureBox();
            this.increaseValue1 = new System.Windows.Forms.PictureBox();
            this.statsButton = new System.Windows.Forms.Label();
            this.convertBox = new System.Windows.Forms.CheckBox();
            this.pickupBox = new System.Windows.Forms.CheckBox();
            this.lookText = new System.Windows.Forms.Label();
            this.itemCategory = new System.Windows.Forms.Label();
            this.itemName = new System.Windows.Forms.Label();
            this.itemPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.decreaseValue10000000000)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.increaseValue10000000000)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.decreaseValue1000000000)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.increaseValue1000000000)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.decreaseValue100000000)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.increaseValue100000000)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.decreaseValue10000000)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.increaseValue10000000)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.decreaseValue1000000)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.increaseValue1000000)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.decreaseValue100000)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.increaseValue100000)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.decreaseValue10000)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.increaseValue10000)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.decreaseValue1000)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.increaseValue1000)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.decreaseValue100)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.increaseValue100)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.decreaseValue10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.increaseValue10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.decreaseValue1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.increaseValue1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // valueDigit10000000000
            // 
            this.valueDigit10000000000.BackColor = System.Drawing.Color.Transparent;
            this.valueDigit10000000000.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.valueDigit10000000000.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.valueDigit10000000000.Location = new System.Drawing.Point(168, 22);
            this.valueDigit10000000000.Name = "valueDigit10000000000";
            this.valueDigit10000000000.Size = new System.Drawing.Size(16, 16);
            this.valueDigit10000000000.TabIndex = 60;
            this.valueDigit10000000000.Text = "0";
            this.valueDigit10000000000.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // decreaseValue10000000000
            // 
            this.decreaseValue10000000000.BackColor = System.Drawing.Color.Transparent;
            this.decreaseValue10000000000.Location = new System.Drawing.Point(167, 38);
            this.decreaseValue10000000000.Name = "decreaseValue10000000000";
            this.decreaseValue10000000000.Size = new System.Drawing.Size(16, 16);
            this.decreaseValue10000000000.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.decreaseValue10000000000.TabIndex = 59;
            this.decreaseValue10000000000.TabStop = false;
            // 
            // increaseValue10000000000
            // 
            this.increaseValue10000000000.BackColor = System.Drawing.Color.Transparent;
            this.increaseValue10000000000.Location = new System.Drawing.Point(167, 6);
            this.increaseValue10000000000.Name = "increaseValue10000000000";
            this.increaseValue10000000000.Size = new System.Drawing.Size(16, 16);
            this.increaseValue10000000000.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.increaseValue10000000000.TabIndex = 58;
            this.increaseValue10000000000.TabStop = false;
            // 
            // valueDigit1000000000
            // 
            this.valueDigit1000000000.BackColor = System.Drawing.Color.Transparent;
            this.valueDigit1000000000.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.valueDigit1000000000.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.valueDigit1000000000.Location = new System.Drawing.Point(184, 22);
            this.valueDigit1000000000.Name = "valueDigit1000000000";
            this.valueDigit1000000000.Size = new System.Drawing.Size(16, 16);
            this.valueDigit1000000000.TabIndex = 57;
            this.valueDigit1000000000.Text = "0";
            this.valueDigit1000000000.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // decreaseValue1000000000
            // 
            this.decreaseValue1000000000.BackColor = System.Drawing.Color.Transparent;
            this.decreaseValue1000000000.Location = new System.Drawing.Point(183, 38);
            this.decreaseValue1000000000.Name = "decreaseValue1000000000";
            this.decreaseValue1000000000.Size = new System.Drawing.Size(16, 16);
            this.decreaseValue1000000000.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.decreaseValue1000000000.TabIndex = 56;
            this.decreaseValue1000000000.TabStop = false;
            // 
            // increaseValue1000000000
            // 
            this.increaseValue1000000000.BackColor = System.Drawing.Color.Transparent;
            this.increaseValue1000000000.Location = new System.Drawing.Point(183, 6);
            this.increaseValue1000000000.Name = "increaseValue1000000000";
            this.increaseValue1000000000.Size = new System.Drawing.Size(16, 16);
            this.increaseValue1000000000.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.increaseValue1000000000.TabIndex = 55;
            this.increaseValue1000000000.TabStop = false;
            // 
            // valueDigit100000000
            // 
            this.valueDigit100000000.BackColor = System.Drawing.Color.Transparent;
            this.valueDigit100000000.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.valueDigit100000000.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.valueDigit100000000.Location = new System.Drawing.Point(200, 22);
            this.valueDigit100000000.Name = "valueDigit100000000";
            this.valueDigit100000000.Size = new System.Drawing.Size(16, 16);
            this.valueDigit100000000.TabIndex = 54;
            this.valueDigit100000000.Text = "0";
            this.valueDigit100000000.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // decreaseValue100000000
            // 
            this.decreaseValue100000000.BackColor = System.Drawing.Color.Transparent;
            this.decreaseValue100000000.Location = new System.Drawing.Point(199, 38);
            this.decreaseValue100000000.Name = "decreaseValue100000000";
            this.decreaseValue100000000.Size = new System.Drawing.Size(16, 16);
            this.decreaseValue100000000.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.decreaseValue100000000.TabIndex = 53;
            this.decreaseValue100000000.TabStop = false;
            // 
            // increaseValue100000000
            // 
            this.increaseValue100000000.BackColor = System.Drawing.Color.Transparent;
            this.increaseValue100000000.Location = new System.Drawing.Point(199, 6);
            this.increaseValue100000000.Name = "increaseValue100000000";
            this.increaseValue100000000.Size = new System.Drawing.Size(16, 16);
            this.increaseValue100000000.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.increaseValue100000000.TabIndex = 52;
            this.increaseValue100000000.TabStop = false;
            // 
            // valueDigit10000000
            // 
            this.valueDigit10000000.BackColor = System.Drawing.Color.Transparent;
            this.valueDigit10000000.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.valueDigit10000000.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.valueDigit10000000.Location = new System.Drawing.Point(216, 22);
            this.valueDigit10000000.Name = "valueDigit10000000";
            this.valueDigit10000000.Size = new System.Drawing.Size(16, 16);
            this.valueDigit10000000.TabIndex = 51;
            this.valueDigit10000000.Text = "0";
            this.valueDigit10000000.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // decreaseValue10000000
            // 
            this.decreaseValue10000000.BackColor = System.Drawing.Color.Transparent;
            this.decreaseValue10000000.Location = new System.Drawing.Point(215, 38);
            this.decreaseValue10000000.Name = "decreaseValue10000000";
            this.decreaseValue10000000.Size = new System.Drawing.Size(16, 16);
            this.decreaseValue10000000.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.decreaseValue10000000.TabIndex = 50;
            this.decreaseValue10000000.TabStop = false;
            // 
            // increaseValue10000000
            // 
            this.increaseValue10000000.BackColor = System.Drawing.Color.Transparent;
            this.increaseValue10000000.Location = new System.Drawing.Point(215, 6);
            this.increaseValue10000000.Name = "increaseValue10000000";
            this.increaseValue10000000.Size = new System.Drawing.Size(16, 16);
            this.increaseValue10000000.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.increaseValue10000000.TabIndex = 49;
            this.increaseValue10000000.TabStop = false;
            // 
            // valueDigit1000000
            // 
            this.valueDigit1000000.BackColor = System.Drawing.Color.Transparent;
            this.valueDigit1000000.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.valueDigit1000000.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.valueDigit1000000.Location = new System.Drawing.Point(232, 22);
            this.valueDigit1000000.Name = "valueDigit1000000";
            this.valueDigit1000000.Size = new System.Drawing.Size(16, 16);
            this.valueDigit1000000.TabIndex = 48;
            this.valueDigit1000000.Text = "0";
            this.valueDigit1000000.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // decreaseValue1000000
            // 
            this.decreaseValue1000000.BackColor = System.Drawing.Color.Transparent;
            this.decreaseValue1000000.Location = new System.Drawing.Point(231, 38);
            this.decreaseValue1000000.Name = "decreaseValue1000000";
            this.decreaseValue1000000.Size = new System.Drawing.Size(16, 16);
            this.decreaseValue1000000.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.decreaseValue1000000.TabIndex = 47;
            this.decreaseValue1000000.TabStop = false;
            // 
            // increaseValue1000000
            // 
            this.increaseValue1000000.BackColor = System.Drawing.Color.Transparent;
            this.increaseValue1000000.Location = new System.Drawing.Point(231, 6);
            this.increaseValue1000000.Name = "increaseValue1000000";
            this.increaseValue1000000.Size = new System.Drawing.Size(16, 16);
            this.increaseValue1000000.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.increaseValue1000000.TabIndex = 46;
            this.increaseValue1000000.TabStop = false;
            // 
            // valueDigit100000
            // 
            this.valueDigit100000.BackColor = System.Drawing.Color.Transparent;
            this.valueDigit100000.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.valueDigit100000.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.valueDigit100000.Location = new System.Drawing.Point(248, 22);
            this.valueDigit100000.Name = "valueDigit100000";
            this.valueDigit100000.Size = new System.Drawing.Size(16, 16);
            this.valueDigit100000.TabIndex = 45;
            this.valueDigit100000.Text = "0";
            this.valueDigit100000.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // decreaseValue100000
            // 
            this.decreaseValue100000.BackColor = System.Drawing.Color.Transparent;
            this.decreaseValue100000.Location = new System.Drawing.Point(247, 38);
            this.decreaseValue100000.Name = "decreaseValue100000";
            this.decreaseValue100000.Size = new System.Drawing.Size(16, 16);
            this.decreaseValue100000.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.decreaseValue100000.TabIndex = 44;
            this.decreaseValue100000.TabStop = false;
            // 
            // increaseValue100000
            // 
            this.increaseValue100000.BackColor = System.Drawing.Color.Transparent;
            this.increaseValue100000.Location = new System.Drawing.Point(247, 6);
            this.increaseValue100000.Name = "increaseValue100000";
            this.increaseValue100000.Size = new System.Drawing.Size(16, 16);
            this.increaseValue100000.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.increaseValue100000.TabIndex = 43;
            this.increaseValue100000.TabStop = false;
            // 
            // valueDigit10000
            // 
            this.valueDigit10000.BackColor = System.Drawing.Color.Transparent;
            this.valueDigit10000.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.valueDigit10000.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.valueDigit10000.Location = new System.Drawing.Point(264, 22);
            this.valueDigit10000.Name = "valueDigit10000";
            this.valueDigit10000.Size = new System.Drawing.Size(16, 16);
            this.valueDigit10000.TabIndex = 42;
            this.valueDigit10000.Text = "0";
            this.valueDigit10000.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // decreaseValue10000
            // 
            this.decreaseValue10000.BackColor = System.Drawing.Color.Transparent;
            this.decreaseValue10000.Location = new System.Drawing.Point(263, 38);
            this.decreaseValue10000.Name = "decreaseValue10000";
            this.decreaseValue10000.Size = new System.Drawing.Size(16, 16);
            this.decreaseValue10000.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.decreaseValue10000.TabIndex = 41;
            this.decreaseValue10000.TabStop = false;
            // 
            // increaseValue10000
            // 
            this.increaseValue10000.BackColor = System.Drawing.Color.Transparent;
            this.increaseValue10000.Location = new System.Drawing.Point(263, 6);
            this.increaseValue10000.Name = "increaseValue10000";
            this.increaseValue10000.Size = new System.Drawing.Size(16, 16);
            this.increaseValue10000.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.increaseValue10000.TabIndex = 40;
            this.increaseValue10000.TabStop = false;
            // 
            // valueDigit1000
            // 
            this.valueDigit1000.BackColor = System.Drawing.Color.Transparent;
            this.valueDigit1000.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.valueDigit1000.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.valueDigit1000.Location = new System.Drawing.Point(280, 22);
            this.valueDigit1000.Name = "valueDigit1000";
            this.valueDigit1000.Size = new System.Drawing.Size(16, 16);
            this.valueDigit1000.TabIndex = 39;
            this.valueDigit1000.Text = "0";
            this.valueDigit1000.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // decreaseValue1000
            // 
            this.decreaseValue1000.BackColor = System.Drawing.Color.Transparent;
            this.decreaseValue1000.Location = new System.Drawing.Point(279, 38);
            this.decreaseValue1000.Name = "decreaseValue1000";
            this.decreaseValue1000.Size = new System.Drawing.Size(16, 16);
            this.decreaseValue1000.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.decreaseValue1000.TabIndex = 38;
            this.decreaseValue1000.TabStop = false;
            // 
            // increaseValue1000
            // 
            this.increaseValue1000.BackColor = System.Drawing.Color.Transparent;
            this.increaseValue1000.Location = new System.Drawing.Point(279, 6);
            this.increaseValue1000.Name = "increaseValue1000";
            this.increaseValue1000.Size = new System.Drawing.Size(16, 16);
            this.increaseValue1000.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.increaseValue1000.TabIndex = 37;
            this.increaseValue1000.TabStop = false;
            // 
            // valueDigit100
            // 
            this.valueDigit100.BackColor = System.Drawing.Color.Transparent;
            this.valueDigit100.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.valueDigit100.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.valueDigit100.Location = new System.Drawing.Point(296, 22);
            this.valueDigit100.Name = "valueDigit100";
            this.valueDigit100.Size = new System.Drawing.Size(16, 16);
            this.valueDigit100.TabIndex = 36;
            this.valueDigit100.Text = "0";
            this.valueDigit100.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // decreaseValue100
            // 
            this.decreaseValue100.BackColor = System.Drawing.Color.Transparent;
            this.decreaseValue100.Location = new System.Drawing.Point(295, 38);
            this.decreaseValue100.Name = "decreaseValue100";
            this.decreaseValue100.Size = new System.Drawing.Size(16, 16);
            this.decreaseValue100.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.decreaseValue100.TabIndex = 35;
            this.decreaseValue100.TabStop = false;
            // 
            // increaseValue100
            // 
            this.increaseValue100.BackColor = System.Drawing.Color.Transparent;
            this.increaseValue100.Location = new System.Drawing.Point(295, 6);
            this.increaseValue100.Name = "increaseValue100";
            this.increaseValue100.Size = new System.Drawing.Size(16, 16);
            this.increaseValue100.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.increaseValue100.TabIndex = 34;
            this.increaseValue100.TabStop = false;
            // 
            // valueDigit10
            // 
            this.valueDigit10.BackColor = System.Drawing.Color.Transparent;
            this.valueDigit10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.valueDigit10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.valueDigit10.Location = new System.Drawing.Point(312, 22);
            this.valueDigit10.Name = "valueDigit10";
            this.valueDigit10.Size = new System.Drawing.Size(16, 16);
            this.valueDigit10.TabIndex = 33;
            this.valueDigit10.Text = "0";
            this.valueDigit10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // decreaseValue10
            // 
            this.decreaseValue10.BackColor = System.Drawing.Color.Transparent;
            this.decreaseValue10.Location = new System.Drawing.Point(311, 38);
            this.decreaseValue10.Name = "decreaseValue10";
            this.decreaseValue10.Size = new System.Drawing.Size(16, 16);
            this.decreaseValue10.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.decreaseValue10.TabIndex = 32;
            this.decreaseValue10.TabStop = false;
            // 
            // increaseValue10
            // 
            this.increaseValue10.BackColor = System.Drawing.Color.Transparent;
            this.increaseValue10.Location = new System.Drawing.Point(311, 6);
            this.increaseValue10.Name = "increaseValue10";
            this.increaseValue10.Size = new System.Drawing.Size(16, 16);
            this.increaseValue10.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.increaseValue10.TabIndex = 31;
            this.increaseValue10.TabStop = false;
            // 
            // valueDigit1
            // 
            this.valueDigit1.BackColor = System.Drawing.Color.Transparent;
            this.valueDigit1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.valueDigit1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.valueDigit1.Location = new System.Drawing.Point(328, 22);
            this.valueDigit1.Name = "valueDigit1";
            this.valueDigit1.Size = new System.Drawing.Size(16, 16);
            this.valueDigit1.TabIndex = 30;
            this.valueDigit1.Text = "0";
            this.valueDigit1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // decreaseValue1
            // 
            this.decreaseValue1.BackColor = System.Drawing.Color.Transparent;
            this.decreaseValue1.Location = new System.Drawing.Point(327, 38);
            this.decreaseValue1.Name = "decreaseValue1";
            this.decreaseValue1.Size = new System.Drawing.Size(16, 16);
            this.decreaseValue1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.decreaseValue1.TabIndex = 29;
            this.decreaseValue1.TabStop = false;
            // 
            // increaseValue1
            // 
            this.increaseValue1.BackColor = System.Drawing.Color.Transparent;
            this.increaseValue1.Location = new System.Drawing.Point(327, 6);
            this.increaseValue1.Name = "increaseValue1";
            this.increaseValue1.Size = new System.Drawing.Size(16, 16);
            this.increaseValue1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.increaseValue1.TabIndex = 28;
            this.increaseValue1.TabStop = false;
            // 
            // statsButton
            // 
            this.statsButton.BackColor = System.Drawing.Color.Transparent;
            this.statsButton.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.statsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statsButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.statsButton.Location = new System.Drawing.Point(34, 120);
            this.statsButton.Name = "statsButton";
            this.statsButton.Padding = new System.Windows.Forms.Padding(2);
            this.statsButton.Size = new System.Drawing.Size(96, 21);
            this.statsButton.TabIndex = 27;
            this.statsButton.Text = "Drops";
            this.statsButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.statsButton.Click += new System.EventHandler(this.statsButton_Click);
            // 
            // convertBox
            // 
            this.convertBox.AutoSize = true;
            this.convertBox.BackColor = System.Drawing.Color.Transparent;
            this.convertBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.convertBox.Location = new System.Drawing.Point(239, 55);
            this.convertBox.Name = "convertBox";
            this.convertBox.Size = new System.Drawing.Size(104, 17);
            this.convertBox.TabIndex = 6;
            this.convertBox.Text = "Convert To Gold";
            this.convertBox.UseVisualStyleBackColor = false;
            this.convertBox.CheckedChanged += new System.EventHandler(this.convertBox_CheckedChanged);
            // 
            // pickupBox
            // 
            this.pickupBox.AutoSize = true;
            this.pickupBox.BackColor = System.Drawing.Color.Transparent;
            this.pickupBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.pickupBox.Location = new System.Drawing.Point(133, 56);
            this.pickupBox.Name = "pickupBox";
            this.pickupBox.Size = new System.Drawing.Size(87, 17);
            this.pickupBox.TabIndex = 5;
            this.pickupBox.Text = "Pick Up Item";
            this.pickupBox.UseVisualStyleBackColor = false;
            this.pickupBox.CheckedChanged += new System.EventHandler(this.pickupBox_CheckedChanged);
            // 
            // lookText
            // 
            this.lookText.AutoSize = true;
            this.lookText.BackColor = System.Drawing.Color.Transparent;
            this.lookText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.lookText.Location = new System.Drawing.Point(141, 75);
            this.lookText.MaximumSize = new System.Drawing.Size(210, 0);
            this.lookText.Name = "lookText";
            this.lookText.Size = new System.Drawing.Size(64, 13);
            this.lookText.TabIndex = 3;
            this.lookText.Text = "You see a...";
            // 
            // itemCategory
            // 
            this.itemCategory.BackColor = System.Drawing.Color.Transparent;
            this.itemCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.itemCategory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.itemCategory.Location = new System.Drawing.Point(34, 23);
            this.itemCategory.MaximumSize = new System.Drawing.Size(96, 28);
            this.itemCategory.Name = "itemCategory";
            this.itemCategory.Size = new System.Drawing.Size(96, 28);
            this.itemCategory.TabIndex = 2;
            this.itemCategory.Text = "category";
            this.itemCategory.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.itemCategory.Click += new System.EventHandler(this.itemCategory_Click);
            // 
            // itemName
            // 
            this.itemName.BackColor = System.Drawing.Color.Transparent;
            this.itemName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.itemName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.itemName.Location = new System.Drawing.Point(34, 89);
            this.itemName.MaximumSize = new System.Drawing.Size(96, 28);
            this.itemName.Name = "itemName";
            this.itemName.Size = new System.Drawing.Size(96, 28);
            this.itemName.TabIndex = 1;
            this.itemName.Text = "name";
            this.itemName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // itemPictureBox
            // 
            this.itemPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.itemPictureBox.Location = new System.Drawing.Point(66, 56);
            this.itemPictureBox.Name = "itemPictureBox";
            this.itemPictureBox.Size = new System.Drawing.Size(32, 32);
            this.itemPictureBox.TabIndex = 0;
            this.itemPictureBox.TabStop = false;
            // 
            // ItemViewForm
            // 
            this.ClientSize = new System.Drawing.Size(378, 151);
            this.Controls.Add(this.valueDigit10000000000);
            this.Controls.Add(this.decreaseValue10000000000);
            this.Controls.Add(this.increaseValue10000000000);
            this.Controls.Add(this.valueDigit1000000000);
            this.Controls.Add(this.decreaseValue1000000000);
            this.Controls.Add(this.increaseValue1000000000);
            this.Controls.Add(this.valueDigit100000000);
            this.Controls.Add(this.decreaseValue100000000);
            this.Controls.Add(this.increaseValue100000000);
            this.Controls.Add(this.valueDigit10000000);
            this.Controls.Add(this.decreaseValue10000000);
            this.Controls.Add(this.increaseValue10000000);
            this.Controls.Add(this.valueDigit1000000);
            this.Controls.Add(this.decreaseValue1000000);
            this.Controls.Add(this.increaseValue1000000);
            this.Controls.Add(this.valueDigit100000);
            this.Controls.Add(this.decreaseValue100000);
            this.Controls.Add(this.increaseValue100000);
            this.Controls.Add(this.valueDigit10000);
            this.Controls.Add(this.decreaseValue10000);
            this.Controls.Add(this.increaseValue10000);
            this.Controls.Add(this.valueDigit1000);
            this.Controls.Add(this.decreaseValue1000);
            this.Controls.Add(this.increaseValue1000);
            this.Controls.Add(this.valueDigit100);
            this.Controls.Add(this.decreaseValue100);
            this.Controls.Add(this.increaseValue100);
            this.Controls.Add(this.valueDigit10);
            this.Controls.Add(this.decreaseValue10);
            this.Controls.Add(this.increaseValue10);
            this.Controls.Add(this.valueDigit1);
            this.Controls.Add(this.decreaseValue1);
            this.Controls.Add(this.increaseValue1);
            this.Controls.Add(this.statsButton);
            this.Controls.Add(this.convertBox);
            this.Controls.Add(this.pickupBox);
            this.Controls.Add(this.lookText);
            this.Controls.Add(this.itemCategory);
            this.Controls.Add(this.itemName);
            this.Controls.Add(this.itemPictureBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ItemViewForm";
            this.Text = "Item View";
            ((System.ComponentModel.ISupportInitialize)(this.decreaseValue10000000000)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.increaseValue10000000000)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.decreaseValue1000000000)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.increaseValue1000000000)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.decreaseValue100000000)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.increaseValue100000000)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.decreaseValue10000000)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.increaseValue10000000)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.decreaseValue1000000)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.increaseValue1000000)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.decreaseValue100000)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.increaseValue100000)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.decreaseValue10000)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.increaseValue10000)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.decreaseValue1000)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.increaseValue1000)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.decreaseValue100)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.increaseValue100)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.decreaseValue10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.increaseValue10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.decreaseValue1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.increaseValue1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void DestroyForm() {

        }

        string prefix;
        private string TooltipFunction(TibiaObject obj) {
            NPC npc = obj as NPC;
            return String.Format("{0} {1} for {2} gold.", prefix, item.displayname, prefix == "Sells" ? buyNPCs[npc] : sellNPCs[npc]);
        }

        private string CreatureTooltipFunction(TibiaObject obj) {
            Creature cr = obj as Creature;
            float percentage = creatures[cr];
            return String.Format("{0}: {1}%", cr.displayname, percentage < 0 ? "Unknown" : percentage.ToString());
        }

        public override void LoadForm() {
            skip_event = true;
            this.SuspendForm();
            this.NotificationInitialize();
            CultureInfo c = System.Threading.Thread.CurrentThread.CurrentCulture;

            for (int i = 0; i < decreaseBoxes.Count; i++) {
                decreaseBoxes[i].Click -= c_Click;
            }
            for (int i = 0; i < increaseBoxes.Count; i++) {
                increaseBoxes[i].Click -= c_Click;
            }

            this.itemName.Text = c.TextInfo.ToTitleCase(item.displayname);
            Font f = MainForm.fontList[0];
            for (int i = 0; i < MainForm.fontList.Count; i++) {
                Font font = MainForm.fontList[i];
                int width = TextRenderer.MeasureText(this.itemName.Text, font).Width;
                if (width < itemName.MaximumSize.Width) {
                    f = font;
                } else {
                    break;
                }
            }
            this.itemName.Font = f;
            this.itemCategory.Text = item.category;
            f = MainForm.fontList[0];
            for (int i = 0; i < MainForm.fontList.Count; i++) {
                Font font = MainForm.fontList[i];
                Size size = TextRenderer.MeasureText(this.itemCategory.Text, font);
                if (size.Width < itemCategory.MaximumSize.Width && size.Height < itemCategory.MaximumSize.Height) {
                    f = font;
                } else {
                    break;
                }
            }
            this.itemCategory.Font = f;


            this.itemPictureBox.BackgroundImage = MainForm.item_background;
            this.lookText.Text = item.look_text;
            this.pickupBox.Checked = !item.discard;
            this.convertBox.Checked = item.convert_to_gold;
            this.itemPictureBox.Image = item.image;
            this.updateValue();

            int base_x = 20, base_y = this.statsButton.Location.Y + this.statsButton.Height + 5;
            int x = 0, y = 0;
            int max_x = 344;
            int spacing = 4;

            // add a tooltip that displays the actual droprate when you mouseover
            ToolTip value_tooltip = new ToolTip();
            value_tooltip.AutoPopDelay = 60000;
            value_tooltip.InitialDelay = 500;
            value_tooltip.ReshowDelay = 0;
            value_tooltip.ShowAlways = true;
            value_tooltip.UseFading = true;

            if (creatures == null) {
                List<NPC> buyNPCList = buyNPCs.Keys.ToList().OrderBy(o => buyNPCs[o]).ToList();
                List<NPC> sellNPCList = sellNPCs.Keys.ToList().OrderBy(o => sellNPCs[o]).ToList();
                List<List<NPC>> npc_lists = new List<List<NPC>>();
                npc_lists.Add(buyNPCList); npc_lists.Add(sellNPCList);
                string[] header_string = { "Buy From:", "Sell To:" };
                string[] info_string = { "Sells", "Buys" };
                List<Control> createdControls = new List<Control>();
                for (int i = 0; i < npc_lists.Count; i++) {
                    prefix = info_string[i];
                    List<NPC> npc_list = npc_lists[i];
                    if (npc_list != null && npc_list.Count > 0) {
                        Label header = new Label();
                        header.ForeColor = MainForm.label_text_color;
                        header.BackColor = Color.Transparent;
                        header.Text = header_string[i];
                        header.Font = MainForm.fontList[5];
                        header.Location = new Point(base_x + x, base_y + y);
                        y = y + header.Size.Height;
                        this.Controls.Add(header);

                        y = y + MainForm.DisplayCreatureList(this.Controls, (npc_list as IEnumerable<TibiaObject>).ToList(), base_x, base_y + y, max_x, spacing, TooltipFunction, 1, createdControls);
                    }
                }
                command_start = "npc" + MainForm.commandSymbol;
                switch_start = "drop" + MainForm.commandSymbol;
                statsButton.Text = "Dropped By";
                statsButton.Name = item.GetName().ToLower();
                foreach (Control control in createdControls)
                    if (control is PictureBox)
                        control.Click += openItemBox;
            } else {
                List<TibiaObject> creatureList = new List<TibiaObject>();
                foreach (Creature cr in creatures.Keys) {
                    creatureList.Add(cr);
                }

                Label header = new Label();
                header.ForeColor = MainForm.label_text_color;
                header.BackColor = Color.Transparent;
                header.Text = "Dropped By";
                header.Font = MainForm.fontList[5];
                header.Location = new Point(base_x + x, base_y + y);
                y = y + header.Size.Height;

                List<Control> createdControls = new List<Control>();
                y = y + MainForm.DisplayCreatureList(this.Controls, creatureList, base_x, base_y + y, max_x, spacing, CreatureTooltipFunction, 1, createdControls);

                command_start = "creature" + MainForm.commandSymbol;
                switch_start = "item" + MainForm.commandSymbol;
                statsButton.Text = "Sold By";
                statsButton.Name = item.GetName().ToLower();
                foreach (Control control in createdControls)
                    control.Click += openItemBox;
            }
            this.Size = new Size(this.Size.Width, base_y + y + 20);
            base.NotificationFinalize();
            this.ResumeForm();
            skip_event = false;
        }

        private string command_start = "npc" + MainForm.commandSymbol;
        private bool clicked = false;
        void openItemBox(object sender, EventArgs e) {
            if (clicked) return;
            clicked = true;
            this.ReturnFocusToTibia();
            MainForm.mainForm.ExecuteCommand(command_start + (sender as Control).Name);
            clicked = false;
        }

        private string switch_start = "drop" + MainForm.commandSymbol;
        private void statsButton_Click(object sender, EventArgs e) {
            if (clicked) return;
            clicked = true;
            this.ReturnFocusToTibia();
            MainForm.mainForm.ExecuteCommand(switch_start + (sender as Control).Name);
            clicked = false;
        }

        private bool skip_event = false;
        private void pickupBox_CheckedChanged(object sender, EventArgs e) {
            if (skip_event) return;
            bool is_checked = (sender as CheckBox).Checked;
            this.ReturnFocusToTibia();
            if (is_checked) MainForm.mainForm.ExecuteCommand("pickup" + MainForm.commandSymbol + item.GetName());
            else MainForm.mainForm.ExecuteCommand("nopickup" + MainForm.commandSymbol + item.GetName());
        }

        private void convertBox_CheckedChanged(object sender, EventArgs e) {
            if (skip_event) return;
            bool is_checked = (sender as CheckBox).Checked;
            this.ReturnFocusToTibia();
            if (is_checked) MainForm.mainForm.ExecuteCommand("convert" + MainForm.commandSymbol + item.GetName());
            else MainForm.mainForm.ExecuteCommand("noconvert" + MainForm.commandSymbol + item.GetName());
        }

        private void itemCategory_Click(object sender, EventArgs e) {
            MainForm.mainForm.ExecuteCommand("category" + MainForm.commandSymbol + item.category);
        }
    }
}
