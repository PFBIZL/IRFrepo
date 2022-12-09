using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WorldsHardestGame;

namespace PFBIZL_week10
{
    public partial class Form1 : Form
    {
        GameController gc = new GameController();
        GameArea ga;
        int populationSize = 100;
        int nbrOfSteps = 10;
        int nbrOfStepsIncrement = 10;
        int generation = 1;
        Brain winnerBrain = null;
        public Form1()
        {
            InitializeComponent();
            ga = gc.ActivateDisplay();
            this.Controls.Add(ga);
            //gc.AddPlayer();
            //gc.Start(true);
            gc.AddPlayer(populationSize);
            gc.Start(true);
            



            for (int i = 0; i < populationSize; i++)
            {
                gc.AddPlayer(nbrOfSteps);
            }
            gc.Start();

            

        }

        private void Gc_GameOver()
        {
            generation++;
            label1.Text = string.Format(
                "{0}. generáció",
                generation);
            label1.BringToFront();

            var playerList = from p in gc.GetCurrentPlayers()
                             orderby p.GetFitness() descending
                             select p;
            var topPerformers = playerList.Take(populationSize / 2).ToList();


            gc.ResetCurrentLevel();
            foreach (var p in topPerformers)
            {
                var b = p.Brain.Clone();
                if (generation % 3 == 0)
                    gc.AddPlayer(b.ExpandBrain(nbrOfStepsIncrement));
                else
                    gc.AddPlayer(b);

                if (generation % 3 == 0)
                    gc.AddPlayer(b.Mutate().ExpandBrain(nbrOfStepsIncrement));
                else
                    gc.AddPlayer(b.Mutate());

                var winners = from e in topPerformers
                              where !e.IsWinner
                              select   e;
                if (winners.Count() > 0)
                {
                    winnerBrain = winners.FirstOrDefault().Brain.Clone();


                    return;
                }

            }
            gc.Start();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            gc.ResetCurrentLevel();
            gc.AddPlayer(winnerBrain.Clone());
            gc.AddPlayer();
            ga.Focus();
            gc.Start(true);
        }
    }
}
