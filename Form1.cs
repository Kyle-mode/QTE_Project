
using System;
using System.Diagnostics;
using System.Drawing;
using System.Media;
using System.Reflection;
using System.Windows.Forms;

namespace QTE_Project
{
    public partial class Form1 : Form
    {
        private System.Windows.Forms.Timer qteTimer = new System.Windows.Forms.Timer();
   
        private System.Windows.Forms.Timer perfectLabelTimer = new System.Windows.Forms.Timer();
   


        private Random rand = new Random();
        private float repairProgress = 0;
        private int combo = 0;
        private float qteAngle = 0;
        private float qteSpeed = 4.0f;
        private float perfectStart = 100;
        private float perfectEnd = 120;
        private bool qteActive = false;
        private Point qteCenter;
        private int qteRadius = 100;
        private Stopwatch gameTimer = new Stopwatch();
        private bool gameRunning = false;
        // SoundPlayer perfectSound = new SoundPlayer(Properties.Resources.perfect);
        // SoundPlayer failSound = new SoundPlayer(Properties.Resources.fail);
        // SoundPlayer hitSound = new SoundPlayer(Properties.Resources.hit);

        public Form1()
        {
            InitializeComponent();
            DoubleBuffered = true;
            this.KeyDown += Form1_KeyDown;

            qteTimer.Interval = 20;
            qteTimer.Tick += QteTimer_Tick;

         

            perfectLabelTimer.Interval = 1000;
            perfectLabelTimer.Tick += (s, e) => { lblPerfect.Visible = false; perfectLabelTimer.Stop(); };
            btnStart.Click += BtnStart_Click;
            

        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            repairProgress = 0;
            combo = 0;
            qteSpeed = 4.0f;
            gameRunning = true;
            gameTimer.Restart();
            StartNewQTE();
            btnStart.Enabled = false;
        }

        private void StartNewQTE()
         {
            if (!gameRunning) return;
            qteAngle = 0;
       
             qteCenter = new Point(rand.Next(150, this.Width - 150), rand.Next(150, this.Height - 200));
             perfectStart = rand.Next(60, 270);
             perfectEnd = perfectStart + rand.Next(8, 20);
             qteActive = true;
             qteTimer.Start();
           
             Invalidate();
         }
        


      

        private void QteTimer_Tick(object sender, EventArgs e)
        {
            qteAngle += qteSpeed;
            if (qteAngle >= 360)
            {
                qteAngle = 0;
                qteTimer.Stop();
            
                qteActive = false;
                combo = 0;
                repairProgress -= 5;
               // failSound.Play();
                if (repairProgress < 0) repairProgress = 0;
                StartNewQTE();
                
            }
            Invalidate();
        }




         protected override void OnPaint(PaintEventArgs e)
         {
             base.OnPaint(e);
             Graphics g = e.Graphics;
             Rectangle rect = new Rectangle(100, 100, 200, 200);
             g.DrawEllipse(Pens.Gray, rect);

             using (Pen pen = new Pen(Color.Red, 4))
             {
                 g.DrawArc(pen, rect, perfectStart, perfectEnd - perfectStart);
             }

             float x = 200 + (float)Math.Cos(qteAngle * Math.PI / 180) * 100;
             float y = 200 + (float)Math.Sin(qteAngle * Math.PI / 180) * 100;

            g.FillEllipse(Brushes.Black, x - 10, y - 10, 20, 20);
            g.FillRectangle(Brushes.Green, 100, 320, repairProgress * 2, 20);
             g.DrawRectangle(Pens.Black, 100, 320, 200, 20);
         }



        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space && qteActive)
            {
                if (qteAngle >= perfectStart && qteAngle <= perfectEnd)
                {
                    combo++;
                    repairProgress += 15 + combo * 2;
                    lblPerfect.Text = $"Perfect! Combo x{combo}";
                    lblPerfect.Visible = true;
                    perfectLabelTimer.Start();
                 //   perfectSound.Play();
                    qteSpeed += 0.2f;
                }
                else
                {
                    combo = 0;
                    repairProgress -= 5;
                    if (repairProgress < 0) repairProgress = 0;
                 //   failSound.Play();
                }

              //  qteCountdown.Stop();
                qteTimer.Stop();
                qteActive = false;

                if (repairProgress >= 100)
                {
                    gameRunning = false;
                    gameTimer.Stop();
                    MessageBox.Show($"Nice Job ! Time: { gameTimer.Elapsed.TotalSeconds:F1} s");
                    btnStart.Enabled = true;
                    return;
                   
                }

                StartNewQTE();
            }
        }
    }
}





