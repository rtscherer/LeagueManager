using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LeagueManager.DataLayer;
using LeagueManager.Domain;
using MySql.Data.Entity;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace LeagueManager.UtilityUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            RefreshListBox1();

            RefreshListBox2();
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            Team team = new Team()
            {
                TeamId = Guid.NewGuid(),
                Name = textBox1.Text,
                LastUpdate = new LastUpdate() { UpdateUser = "UI", UpdateDate = DateTime.Now }
            };
            new TeamAccessor().InsertTeam(team);

            Roster roster = new Roster()
            {
                RosterId = Guid.NewGuid(),
                team_id_fk = team.TeamId,
                LastUpdate = new LastUpdate() { UpdateUser = "UI", UpdateDate = DateTime.Now }
            };
            new RosterAccessor().InsertRoster(roster);

            RefreshListBox1();
            
            textBox1.Text = string.Empty;

            label9.Text = "New Team and Empty Roster Added!";
        }

        private void RefreshListBox1()
        {
            listBox1.Items.Clear();
            var teams = new TeamAccessor().GetTeams;

            foreach (var team in teams)
            {
                listBox1.Items.Add(team.Name);
            }
        }

        private void RefreshListBox2()
        {
            listBox2.Items.Clear();
            var contacts = new ContactPersonAccessor().GetContacts;

            foreach (var contact in contacts)
            {
                listBox2.Items.Add(contact.FirstName + " " + contact.LastName);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int selectedTeam = listBox1.SelectedIndex;
            Team team = new TeamAccessor().GetTeams.ToArray()[selectedTeam];
            var rosters = new RosterAccessor().GetRosters;

            var roster = (from r in rosters
                         where r.team_id_fk == team.TeamId
                         select r).FirstOrDefault();

            Player player = new Player()
            {
                PlayerId = Guid.NewGuid(),
                FirstName = firstName.Text,
                LastName = lastName.Text,
                PrimaryPosition = primaryPosition.Text,
                PhoneNumber = string.Empty,
                HasSignedRoster = checkBox1.Checked,
                HasPayedLeagueFee = checkBox2.Checked,
                EMail = string.Empty,
                BattingPosition = "R",
                SecondaryPosition = string.Empty,
                roster_id_fk = roster.RosterId,
                LastUpdate = new LastUpdate() { UpdateUser = "UI", UpdateDate = DateTime.Now }
            };
            new PlayerAccessor().InsertPlayer(player);

            label9.Text = string.Format("Player Added to {0}", team.Name);
        }
    }
}
