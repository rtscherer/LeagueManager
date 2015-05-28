using LeagueManager.DataLayer;
using LeagueManager.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LeagueManager.UtilityUI
{
    public partial class RosterGrid : Form
    {
        public RosterGrid()
        {
            InitializeComponent();

            PopulateComboBox();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //int selectedTeam = comboBox1.SelectedIndex;
            //Team team = new TeamAccessor().GetAllTeams.ToArray()[selectedTeam];
            //var rosters = new RosterAccessor().GetRosters;
            //var roster = (from r in rosters
            //             where r.team_id_fk == team.TeamId
            //             select r).FirstOrDefault();

            //if (roster == null) return;

            //var players = new PlayerAccessor().GetPlayers(roster);

            //dataGridView1.DataSource = players.ToList();
        }

        private void PopulateComboBox()
        {
            var teams = new TeamAccessor().GetAllTeams;
            List<string> teamNames = new List<string>();
            foreach (var team in teams)
                teamNames.Add(team.Name);

            comboBox1.DataSource = teamNames;
            comboBox1.DisplayMember = "Team";
        }

        private void Save_Click(object sender, EventArgs e)
        {
            //List<Player> players = new List<Player>();
            //foreach(DataGridViewRow row in dataGridView1.Rows)
            //{
                
            //        Player player = new Player();
            //        player.PlayerId = (Guid)row.Cells[0].Value;
            //        player.roster_id_fk = (Guid)row.Cells[1].Value;

            //        player.FirstName = row.Cells[3].Value.ToString();
            //        player.LastName = row.Cells[4].Value.ToString();
            //        player.PhoneNumber = row.Cells[5].Value.ToString();
            //        player.EMail = row.Cells[6].Value.ToString();
            //        new PlayerAccessor().DeletePlayer(player);
            //        new PlayerAccessor().InsertPlayer(player);
            //        players.Add(player);
            //}

            //dataGridView1.DataSource = players;
        }
    }
}
