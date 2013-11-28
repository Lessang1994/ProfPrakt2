﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Sokolov_laba_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Close_Btn_Click(object sender, EventArgs e)
        {
            Close();
        }
        int[][] Matr = new int[8][];
        int[] V = { 0, 1, 2, 3, 4, 5, 6, 7 };
        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 8; i++)
            {
                Matr[i] = new int[8];
             
            }
            Matr[1][2] = 1;
            Matr[1][6] = 1;
            Matr[2][5] = 1;
            Matr[2][7] = 1;
            Matr[3][1] = 1;
            Matr[3][4] = 1;
            Matr[3][7] = 1;
            Matr[4][5] = 1;
            Matr[5][6] = 1;
            Matr[6][2] = 1;
            Matr[7][5] = 1;
        }

        int[] A = new int[] { };
        int[] B = new int[] { };

        private void button1_Click(object sender, EventArgs e)
        {
            form_vec_vert(2);
            form_vec_gor(2);
            output();
            cut();
            while (Matr.Length > 1)
            {
                form_vec_vert(1);
                form_vec_gor(1);
                output();
                cut();
            }
        }

        void form_vec_gor(int p)
        {
            bool pr;
            Array.Resize(ref B, Matr.Length);
            int r = B.Length;
            for (int i = 1; i < B.Length; i++)
                B[i] = -1;
            int col = 0;
            B[p] = col;
            do
            {
                col++;
                pr = false;
                for (int i = 1; i < B.Length; i++)
                    if (B[i] == col - 1)
                        call_gor(col, ref pr, i);
            }
            while (pr);
        }

        void call_gor(int col, ref bool pr, int j)
        {
            for (int p = 1; p < A.Length; p++)
                if (Matr[p][j] == 1 && (B[p] == -1 || B[p] > col) && p != j)
                {
                    pr = true;
                    B[p] = col;
                }
        }


        void form_vec_vert(int p)
        {
            bool pr;
            Array.Resize(ref A, Matr.Length);
            int r = A.Length;
            for (int i = 1; i < A.Length; i++)
                A[i] = -1;
            int col = 0;
            A[p] = col;

            do
            {
                col++;
                pr = false;
                for (int i = 1; i < A.Length; i++)
                    if (A[i] == col - 1)
                        call_vert(col, ref pr, i);
            }
            while (pr);
        }

        void call_vert(int col, ref bool pr, int p)
        {
            for (int j = 1; j < A.Length; j++)
                if (Matr[p][j] == 1 && (A[j] == -1 || A[j] > col) && p != j)
                {
                    pr = true;
                    A[j] = col;
                }
        }
    }
}

