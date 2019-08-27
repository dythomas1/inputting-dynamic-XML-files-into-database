using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;
using System.Xml;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase file)
        {
            string path = "";
            if (file != null && file.ContentLength > 0)
            {
                try
                {
                    path = Path.Combine(Server.MapPath("~/bin"),
                                               Path.GetFileName(file.FileName));
                    file.SaveAs(path);
                    ViewBag.Message = "File uploaded successfully";
                }
                catch (Exception ex)
                {
                    ViewBag.Message = "ERROR:" + ex.Message.ToString();
                }
            }
            else
            {
                ViewBag.Message = "You have not specified a file.";
            }

            StringBuilder output = new StringBuilder();

            #region variables
            
            string fumbles;
            string fumblesLost;
            string rushAtt;
            string rushYds;
            string rushGain;
            string rushLoss;
            string rushTd;
            string rushLong;
            string passComp;
            string passAtt;
            string passInt;
            string passYds;
            string passTd;
            string passLong;
            string passSacks;
            string passSackYds;
            string rcvNo;
            string rcvYds;
            string rcvTd;
            string rcvLong;
            string puntNo;
            string puntYds;
            string puntAvg;
            string puntLong;
            string puntBlkd;
            string puntTb;
            string puntFc;
            string puntPlus50;
            string puntInside20;
            string koAtt;
            string koYds;
            string koOb;
            string touchbacks;
            string fgAtt;
            string fgLong;
            string fgBlkd;
            string fgMade;
            string patAtt;
            string patMade;
            string krTd;
            string krYds;
            string krNo;
            string krLong;
            string prTd;
            string prYds;
            string prNo;
            string prLong;
            string irTd;
            string irYds;
            string irNo;
            string irLong;
            string defTackUa;
            string defTackA;
            string defTflUa;
            string defTflA;
            string defTflYds;
            string defSacks;
            string defSackYds;
            string defBrup;
            string defQbh;
            string defBlkd;
            string defFf;
            string defFr;
            string defFrYds;
            string defInt;
            string defIntYds;
            string scoringTd;
            string scoringFg;
            string scoringPatKick;
            string scoringPatRush;
            string scoringPatRcv;
            string scoringSaf;

            string playerId;
            string playerName;
            string playerUni;
            string playerClass;
            string playerPos;
            string playerGp;
            string playerGs;

            //team totals
            string teamTotOffPlays;
            string teamTotOffYards;
            string teamTotOffAvg;
            string teamFirstDownNo;
            string teamFirstDownRush;
            string teamFirstDownPass;
            string teamFirstDownPen;
            string teamPenaltyNo;
            string teamPenaltyYds;
            string teamThirdConv;
            string teamThirdAtt;
            string teamFourthConv;
            string teamFourthAtt;
            string teamFumbles;
            string teamFumblesLost;
            string teamMiscYds;
            string teamTimeOfPoss;
            string teamOnsideAtt;
            string teamOnsideMade;
            string teamPointsOffTurnovers;
            string teamRzAtt;
            string teamRzScores;
            string teamRzPoints;
            string teamRzTdRush;
            string teamRzTdPass;
            string teamRzFgMade;
            string teamRzEndFga;
            string teamRzEndDowns;
            string teamRzEndInt;
            string teamRzEndFumb;
            string teamRzEndHalf;
            string teamRzEndGame;
            string teamRushAtt;
            string teamRushYds;
            string teamRushGain;
            string teamRushLoss;
            string teamRushTd;
            string teamRushLong;
            string teamPassComp;
            string teamPassAtt;
            string teamPassInt;
            string teamPassYds;
            string teamPassTd;
            string teamPassLong;
            string teamPassSacks;
            string teamPassSackYds;
            string teamRcvNo;
            string teamRcvYds;
            string teamRcvTd;
            string teamRcvLong;
            string teamPuntNo;
            string teamPuntYds;
            string teamPuntLong;
            string teamPuntBlkd;
            string teamPuntTb;
            string teamPuntFc;
            string teamPuntPlus50;
            string teamPuntInside20;
            string teamKoAtt;
            string teamKoYds;
            string teamKoOb;
            string teamKoTb;
            string teamFgAtt;
            string teamFgLong;
            string teamFgBlkd;
            string teamFgMade;
            string teamPatAtt;
            string teamPatMade;
            string teamKrTd;
            string teamKrYds;
            string teamKrNo;
            string teamKrLong;
            string teamPrTd;
            string teamPrYds;
            string teamPrNo;
            string teamPrLong;
            string teamIrTd;
            string teamIrYds;
            string teamIrNo;
            string teamIrLong;

            //scores tags
            string scoresVh;
            string scoresTeam;
            string scoresQtr;
            string scoresClock;
            string scoresType;
            string scoresHow;
            string scoresYds;
            string scoresScorer;
            string scoresPasser;
            string scoresPatBy;
            string scoresPatType;
            string scoresPatRes;
            string scoresPlays;
            string scoresDrive;
            string scoresTop;
            string scoresVScore;
            string scoresHScore;
            string scoresDriveIndex;


            //QTR Summary Properties
            string qtrSummaryFirstDownNo;
            string qtrSummaryFirstDownRush;
            string qtrSummaryFirstDownPass;
            string qtrSummaryFirstDownPenalty;
            string qtrSummaryPenaltiesNo;
            string qtrSummaryPenaltiesYds;
            string qtrSummaryConversionsThirdConv;
            string qtrSummaryConversionsThirdAtt;
            string qtrSummaryConversionsFourthConv;
            string qtrSummaryConversionsFourthAtt;
            string qtrSummaryFumblesNo;
            string qtrSummaryFumblesLost;
            string qtrSummaryMiscYds;
            string qtrSummaryMiscTop;
            string qtrSummaryMiscOna;
            string qtrSummaryMiscOnm;
            string qtrSummaryMiscPtsto;
            string qtrSummaryRushAtt;
            string qtrSummaryRushYds;
            string qtrSummaryRushGain;
            string qtrSummaryRushLoss;
            string qtrSummaryRushTd;
            string qtrSummaryRushLong;
            string qtrSummaryPassComp;
            string qtrSummaryPassAtt;
            string qtrSummaryPassInt;
            string qtrSummaryPassYds;
            string qtrSummaryPassTd;
            string qtrSummaryPassLong;
            string qtrSummaryPassSacks;
            string qtrSummaryPassSackYds;
            string qtrSummaryRcvNo;
            string qtrSummaryRcvYds;
            string qtrSummaryRcvTd;
            string qtrSummaryRcvLong;
            string qtrSummaryPuntNo;
            string qtrSummaryPuntYds;
            string qtrSummaryPuntAvg;
            string qtrSummaryPuntLong;
            string qtrSummaryPuntBlkd;
            string qtrSummaryPuntTb;
            string qtrSummaryPuntFc;
            string qtrSummaryPuntPlus50;
            string qtrSummaryPuntInside20;
            string qtrSummaryKoNo;
            string qtrSummaryKoYds;
            string qtrSummaryKoOb;
            string qtrSummaryKoTb;
            string qtrSummaryFgAtt;
            string qtrSummaryFgLong;
            string qtrSummaryFgBlkd;
            string qtrSummaryFgMade;
            string qtrSummaryPatKickAtt;
            string qtrSummaryPatKickMade;
            string qtrSummaryDefenseTackua;
            string qtrSummaryDefenseTacka;
            string qtrSummaryDefenseSacks;
            string qtrSummaryDefenseSackyds;
            string qtrSummaryKrNo;
            string qtrSummaryKrYds;
            string qtrSummaryKrTd;
            string qtrSummaryKrLong;
            string qtrSummaryPrNo;
            string qtrSummaryPrYds;
            string qtrSummaryPrTd;
            string qtrSummaryPrLong;
            string qtrSummaryScoringTd;
            string qtrSummaryScoringFg;
            string qtrSummaryScoringSaf;
            string qtrSummaryScoringPatKick;
            string qtrSummaryScoringPatRush;
            string qtrSummaryScoringPatRcv;
            string qtrSummaryIrNo;
            string qtrSummaryIrYds;
            string qtrSummaryIrTd;
            string qtrSummaryIrLong;



            //longplays
            string longplayThresh;
            string longplayVh;
            string longplayId;
            string longplayYds;
            string longplayPlay;
            string longplayPlayers;
            string longplayTd;

            //TODO: Add to database and take out append lines
            #endregion

            using (var db = new UAAthleticsEntities())
            {

                Game game = new Game();
                Official official = new Official();
                TeamGame visTeamGame = new TeamGame();
                TeamGame homeTeamGame = new TeamGame();
                Linescore visLinescore = new Linescore();
                Linescore homeLinescore = new Linescore();
                Lineprd lineprd = new Lineprd();
                PlayerGame playerGame = new PlayerGame();
                Player player = new Player();
                Pass pass = new Pass();
                Rush rush = new Rush();
                Rcv rcv = new Rcv();
                Punt punt = new Punt();
                Ko ko = new Ko();
                Fg fg = new Fg();
                Pat pat = new Pat();
                Kr kr = new Kr();
                Pr pr = new Pr();
                Ir ir = new Ir();
                Scoring scoring = new Scoring();
                Defense defense = new Defense();
                Fumble fumble = new Fumble();
                Score score = new Score();
                QtrSummary qtrSummary = new QtrSummary();
                LongPlay longPlay = new LongPlay();

                Team findVisTeam = new Team();
                Team findHomeTeam = new Team();
                Player findPlayer = new Player();

                DateTime gameDate;
                DateTime lastGame;
                TimeSpan ts;
                decimal yearsSince;

                List<Lineprd> visLineprds = new List<Lineprd>();
                List<Lineprd> homeLineprds = new List<Lineprd>();

                XmlDocument doc = new XmlDocument();
                doc.Load(path);

                using (XmlReader reader = XmlReader.Create(path))
                {

                    XmlNode playerNode = null;
                    XmlNode teamNode = null;
                    XmlNode firstDownNode = null;
                    XmlNode penaltyNode = null;
                    XmlNode conversionsNode = null;
                    XmlNode redzoneNode = null;
                    XmlNode passNode = null;
                    XmlNode rushNode = null;
                    XmlNode rcvNode = null;
                    XmlNode fumblesNode = null;
                    XmlNode puntNode = null;
                    XmlNode koNode = null;
                    XmlNode fgNode = null;
                    XmlNode patNode = null;
                    XmlNode defenseNode = null;
                    XmlNode krNode = null;
                    XmlNode prNode = null;
                    XmlNode irNode = null;
                    XmlNode scoringNode = null;
                    XmlNode miscNode = null;
                    XmlNode scoresNode = null;
                    XmlNode qtrSummaryNode = null;
                    XmlNode longplayNode = null;

                    //fbgame
                    reader.ReadToFollowing("fbgame");
                    //TODO: Add neutralgame, nitegame, leaguename, postseason
                    //venue
                    reader.ReadToFollowing("venue");
                    //reader.MoveToAttribute("gameid");
                    reader.MoveToAttribute("visid");
                    game.visId = reader.Value;
                    reader.MoveToAttribute("homeid");
                    game.homeId = reader.Value;
                    reader.MoveToAttribute("visname");
                    game.visName = reader.Value;
                    reader.MoveToAttribute("homename");
                    game.homeName = reader.Value;
                    reader.MoveToAttribute("date");
                    game.date_ = reader.Value;
                    reader.MoveToAttribute("location");
                    game.location_ = reader.Value;
                    reader.MoveToAttribute("stadium");
                    game.stadium = reader.Value;
                    reader.MoveToAttribute("start");
                    game.startTime = reader.Value;
                    reader.MoveToAttribute("end");
                    game.endTime = reader.Value;
                    reader.MoveToAttribute("duration");
                    game.duration = reader.Value;
                    reader.MoveToAttribute("attend");
                    game.attendance = reader.Value;
                    reader.MoveToAttribute("temp");
                    game.temp = reader.Value;
                    reader.MoveToAttribute("wind");
                    game.wind = reader.Value;
                    reader.MoveToAttribute("weather");
                    game.weather = reader.Value;

                    game.game_Id = game.visId + "-" + game.homeId + "-" + game.date_;

                    db.Games.Add(game);

                    //output.AppendLine("Gameid: " + gameId);
                    //output.AppendLine("  VisId: " + visId);
                    //output.AppendLine("  HomeId: " + homeId);
                    //output.AppendLine("  VisName: " + visName);
                    //output.AppendLine("  HomeName: " + homeName);
                    //output.AppendLine("  Date: " + date);
                    //output.AppendLine("  Location: " + location);
                    //output.AppendLine("  Stadium: " + stadium);
                    //output.AppendLine("  Start: " + startTime);
                    //output.AppendLine("  End: " + endTime);
                    //output.AppendLine("  Duration: " + duration);
                    //output.AppendLine("  Attendance: " + attendance);
                    //output.AppendLine("  Temp: " + temp);
                    //output.AppendLine("  Wind: " + wind);
                    //output.AppendLine("  Weather: " + weather);

                    //officials
                    reader.ReadToFollowing("officials");
                    output.AppendLine("Officials");
                    reader.MoveToFirstAttribute();
                    official.title = reader.Name;
                    official.name = reader.Value;
                    official.game_Id = game.game_Id;

                    db.Officials.Add(official);
                    //output.AppendLine("  " + title + ": " + name);
                    while (reader.MoveToNextAttribute())
                    {
                        official = new Official();

                        official.title = reader.Name;
                        official.name = reader.Value;
                        official.game_Id = game.game_Id;

                        db.Officials.Add(official);
                        //output.AppendLine("  " + title + ": " + name);
                    }

                    #region visiting team
                    //visiting team
                    teamNode = doc.SelectSingleNode("/fbgame/team[1]");

                    reader.ReadToFollowing("team");
                    reader.MoveToAttribute("name");
                    visTeamGame.teamName = reader.Value;
                    //output.AppendLine("Visitor: " + teamname);

                    reader.MoveToAttribute("vh");
                    visTeamGame.vh = reader.Value;

                    reader.MoveToAttribute("code");
                    visTeamGame.code = reader.Value;

                    reader.MoveToAttribute("record");
                    visTeamGame.record = reader.Value;
                    //output.AppendLine("  ----Record: " + visTeamGame.record);

                    reader.MoveToAttribute("conf-record");
                    visTeamGame.confRecord = reader.Value;

                    reader.MoveToAttribute("abb");
                    visTeamGame.abb = reader.Value;

                    bool flag = false;

                    for (int x = 0; x < teamNode.Attributes.Count; x++)
                    {
                        if (teamNode.Attributes[x].Name == "rank")
                        {
                            reader.MoveToAttribute("rank");
                            visTeamGame.rank_ = reader.Value;
                            //output.AppendLine("  ----Ranking: " + rank);
                            flag = true;
                        }
                    }

                    if (flag == false)
                    {
                        visTeamGame.rank_ = "NR";
                        //output.AppendLine("  ----Ranking: " + rank);
                    }

                    //linescore
                    reader.ReadToFollowing("linescore");
                    reader.MoveToAttribute("prds");
                    visLinescore.prds = Convert.ToDecimal(reader.Value);
                    //output.AppendLine("Periods: " + prds);
                    reader.MoveToAttribute("line");
                    visLinescore.line = reader.Value;
                    //output.AppendLine("Line: " + line);
                    reader.MoveToAttribute("score");
                    visLinescore.score = Convert.ToDecimal(reader.Value);
                    //output.AppendLine("Score: " + score);

                    //lineprd (each)
                    reader.ReadToFollowing("lineprd");
                    reader.MoveToAttribute("prd");
                    lineprd.prd = Convert.ToDecimal(reader.Value);
                    reader.MoveToAttribute("score");
                    lineprd.score = Convert.ToDecimal(reader.Value);

                    visLineprds.Add(lineprd);
                    //output.AppendLine("  " + prd + ": " + prdscore);
                    while (reader.ReadToNextSibling("lineprd"))
                    {
                        lineprd = new Lineprd();

                        reader.MoveToAttribute("prd");
                        lineprd.prd = Convert.ToDecimal(reader.Value);
                        reader.MoveToAttribute("score");
                        lineprd.score = Convert.ToDecimal(reader.Value);

                        visLineprds.Add(lineprd);
                        //output.AppendLine("  " + prd + ": " + prdscore);
                    }


                    ////totals
                    //reader.ReadToFollowing("totals");
                    ////reader.MoveToFirstAttribute();
                    ////teamTotOffPlays = reader.Value;
                    ////output.AppendLine("Total Plays: " + teamTotOffPlays);
                    ////reader.MoveToNextAttribute();
                    ////teamTotOffYards = reader.Value;
                    ////output.AppendLine("Total Yards: " + teamTotOffYards);
                    ////reader.MoveToNextAttribute();
                    ////teamTotOffAvg = reader.Value;
                    ////output.AppendLine("Yds/Play: " + teamTotOffAvg);

                    //first downs
                    firstDownNode = doc.SelectSingleNode("/fbgame/team[1]/totals/firstdowns");

                    if (firstDownNode != null)
                    {
                        reader.ReadToFollowing("firstdowns");
                        reader.MoveToAttribute("no");
                        //teamFirstDownNo = reader.Value;
                        visTeamGame.firstDownNo = Convert.ToDecimal(reader.Value);
                        //output.AppendLine("First Downs: " + visTeamGame.TeamFirstDownNo);
                        reader.MoveToAttribute("rush");
                        //teamFirstDownRush = reader.Value;
                        visTeamGame.firstDownRush = Convert.ToDecimal(reader.Value);
                        //output.AppendLine("   ----Rush: " + visTeamGame.TeamFirstDownRush);
                        reader.MoveToAttribute("pass");
                        //teamFirstDownPass = reader.Value;
                        visTeamGame.firstDownPass = Convert.ToDecimal(reader.Value);
                        //output.AppendLine("   ----Pass: " + visTeamGame.TeamFirstDownPass);
                        reader.MoveToAttribute("penalty");
                        //teamFirstDownPen = reader.Value;
                        visTeamGame.firstDownPen = Convert.ToDecimal(reader.Value);
                        //output.AppendLine("   ----Penalty: " + visTeamGame.TeamFirstDownPen);
                    }

                    //penalties
                    penaltyNode = doc.SelectSingleNode("/fbgame/team[1]/totals/penalties");

                    if (penaltyNode != null)
                    {
                        reader.ReadToFollowing("penalties");
                        reader.MoveToAttribute("no");
                        //teamPenaltyNo = reader.Value;
                        visTeamGame.penaltyNo = Convert.ToDecimal(reader.Value);
                        reader.MoveToAttribute("yds");
                        //teamPenaltyYds = reader.Value;
                        visTeamGame.penaltyYds = Convert.ToDecimal(reader.Value);
                        //output.AppendLine("Penalties: " + visTeamGame.TeamPenaltyNo + " - " + visTeamGame.TeamPenaltyYds + " yds");
                    }

                    //conversions
                    conversionsNode = doc.SelectSingleNode("/fbgame/team[1]/totals/conversions");

                    if (conversionsNode != null)
                    {
                        reader.ReadToFollowing("conversions");
                        reader.MoveToAttribute("thirdconv");
                        //teamThirdConv = reader.Value;
                        visTeamGame.thirdConv = Convert.ToDecimal(reader.Value);
                        reader.MoveToAttribute("thirdatt");
                        //teamThirdAtt = reader.Value;
                        visTeamGame.thirdAtt = Convert.ToDecimal(reader.Value);
                        reader.MoveToAttribute("fourthconv");
                        //teamFourthConv = reader.Value;
                        visTeamGame.fourthConv = Convert.ToDecimal(reader.Value);
                        reader.MoveToAttribute("fourthatt");
                        //teamFourthAtt = reader.Value;
                        visTeamGame.fourthAtt = Convert.ToDecimal(reader.Value);
                        //output.AppendLine("Conversions: ");
                        //output.AppendLine("  ---3rd down: " + visTeamGame.TeamThirdConv + "-" + visTeamGame.TeamThirdAtt);
                        //output.AppendLine("  ---4th down: " + visTeamGame.TeamFourthConv + "-" + visTeamGame.TeamFourthAtt);
                    }

                    //fumbles
                    fumblesNode = doc.SelectSingleNode("/fbgame/team[1]/totals/fumbles");

                    if (fumblesNode != null)
                    {
                        reader.ReadToFollowing("fumbles");
                        reader.MoveToAttribute("no");
                        //teamFumbles = reader.Value;
                        visTeamGame.fumbles = Convert.ToDecimal(reader.Value);
                        reader.MoveToAttribute("lost");
                        //teamFumblesLost = reader.Value;
                        visTeamGame.fumblesLost = Convert.ToDecimal(reader.Value);
                        //output.AppendLine("Fumbles: " + visTeamGame.TeamFumbles);
                        //output.AppendLine("  ---Lost: " + visTeamGame.TeamFumblesLost);
                    }

                    //misc
                    miscNode = doc.SelectSingleNode("/fbgame/team[1]/totals/misc");

                    if (miscNode != null)
                    {
                        reader.ReadToFollowing("misc");
                        reader.MoveToAttribute("yds");
                        //teamMiscYds = reader.Value;
                        visTeamGame.miscYds = Convert.ToDecimal(reader.Value);
                        reader.MoveToAttribute("top");
                        visTeamGame.timeOfPoss = reader.Value;
                        reader.MoveToAttribute("ona");
                        //teamOnsideAtt = reader.Value;
                        visTeamGame.onsideAtt = Convert.ToDecimal(reader.Value);
                        reader.MoveToAttribute("onm");
                        //teamOnsideMade = reader.Value;
                        visTeamGame.onsideMade = Convert.ToDecimal(reader.Value);
                        reader.MoveToAttribute("ptsto");
                        //teamPointsOffTurnovers = reader.Value;
                        visTeamGame.pointsOffTurnovers = Convert.ToDecimal(reader.Value);
                        //output.AppendLine("Misc. Yds: " + visTeamGame.TeamMiscYds);
                        //output.AppendLine("T.O.P.: " + teamTimeOfPoss);
                        //output.AppendLine("Onside Kicks (made-att): " + visTeamGame.TeamOnsideMade + "-" + visTeamGame.TeamOnsideAtt);
                        //output.AppendLine("Pts Off Turnovers: " + visTeamGame.TeamPointsOffTurnovers);
                    }

                    //redzone
                    redzoneNode = doc.SelectSingleNode("/fbgame/team[1]/totals/redzone");

                    if (redzoneNode != null)
                    {
                        reader.ReadToFollowing("redzone");
                        reader.MoveToAttribute("att");
                        //teamRzAtt = reader.Value;
                        visTeamGame.rzAtt = Convert.ToDecimal(reader.Value);
                        reader.MoveToAttribute("scores");
                        //teamRzScores = reader.Value;
                        visTeamGame.rzScores = Convert.ToDecimal(reader.Value);
                        reader.MoveToAttribute("points");
                        //teamRzPoints = reader.Value;
                        visTeamGame.rzPoints = Convert.ToDecimal(reader.Value);
                        reader.MoveToAttribute("tdrush");
                        //teamRzTdRush = reader.Value;
                        visTeamGame.rzTdRush = Convert.ToDecimal(reader.Value);
                        reader.MoveToAttribute("tdpass");
                        //teamRzTdPass = reader.Value;
                        visTeamGame.rzTdPass = Convert.ToDecimal(reader.Value);
                        reader.MoveToAttribute("fgmade");
                        //teamRzFgMade = reader.Value;
                        visTeamGame.rzFgMade = Convert.ToDecimal(reader.Value);
                        reader.MoveToAttribute("endfga");
                        //teamRzEndFga = reader.Value;
                        visTeamGame.rzEndFga = Convert.ToDecimal(reader.Value);
                        reader.MoveToAttribute("enddowns");
                        //teamRzEndDowns = reader.Value;
                        visTeamGame.rzEndDowns = Convert.ToDecimal(reader.Value);
                        reader.MoveToAttribute("endint");
                        //teamRzEndInt = reader.Value;
                        visTeamGame.rzEndInt = Convert.ToDecimal(reader.Value);
                        reader.MoveToAttribute("endfumb");
                        //teamRzEndFumb = reader.Value;
                        visTeamGame.rzEndFumb = Convert.ToDecimal(reader.Value);
                        reader.MoveToAttribute("endhalf");
                        //teamRzEndHalf = reader.Value;
                        visTeamGame.rzEndHalf = Convert.ToDecimal(reader.Value);
                        reader.MoveToAttribute("endgame");
                        //teamRzEndGame = reader.Value;
                        visTeamGame.rzEndGame = Convert.ToDecimal(reader.Value);
                        //output.AppendLine("Redzone: ");
                        //output.AppendLine("  ---Attempts: " + visTeamGame.TeamRzAtt);
                        //output.AppendLine("  ---Scores: " + visTeamGame.TeamRzScores);
                        //output.AppendLine("  ---Points: " + visTeamGame.TeamRzPoints);
                        //output.AppendLine("  ---Rush TD: " + visTeamGame.TeamRzTdRush);
                        //output.AppendLine("  ---Pass TD: " + visTeamGame.TeamRzTdPass);
                        //output.AppendLine("  ---FG Made: " + visTeamGame.TeamRzFgMade);
                        //output.AppendLine("  ---End FGA: " + visTeamGame.TeamRzEndFga);
                        //output.AppendLine("  ---End Downs: " + visTeamGame.TeamRzEndDowns);
                        //output.AppendLine("  ---End Int: " + visTeamGame.TeamRzEndInt);
                        //output.AppendLine("  ---End Fumb: " + visTeamGame.TeamRzEndFumb);
                        //output.AppendLine("  ---End Half: " + visTeamGame.TeamRzEndHalf);
                        //output.AppendLine("  ---End Game: " + visTeamGame.TeamRzEndGame);
                    }

                    //rushing
                    rushNode = doc.SelectSingleNode("/fbgame/team[1]/totals/rush");

                    if (rushNode != null)
                    {
                        reader.ReadToFollowing("rush");
                        reader.MoveToAttribute("att");
                        //teamRushAtt = reader.Value;
                        visTeamGame.rushAtt = Convert.ToDecimal(reader.Value);
                        reader.MoveToAttribute("yds");
                        //teamRushYds = reader.Value;
                        visTeamGame.rushYds = Convert.ToDecimal(reader.Value);
                        reader.MoveToAttribute("gain");
                        //teamRushGain = reader.Value;
                        visTeamGame.rushGain = Convert.ToDecimal(reader.Value);
                        reader.MoveToAttribute("loss");
                        //teamRushLoss = reader.Value;
                        visTeamGame.rushLoss = Convert.ToDecimal(reader.Value);
                        reader.MoveToAttribute("td");
                        //teamRushTd = reader.Value;
                        visTeamGame.rushTd = Convert.ToDecimal(reader.Value);
                        reader.MoveToAttribute("long");
                        //teamRushLong = reader.Value;
                        visTeamGame.rushLong = Convert.ToDecimal(reader.Value);
                        //output.AppendLine("Rushing: ");
                        //output.AppendLine("  ---Attempts: " + visTeamGame.TeamRushAtt);
                        //output.AppendLine("  ---Yds: " + visTeamGame.TeamRushYds);
                        //output.AppendLine("  ---Gain: " + visTeamGame.TeamRushGain);
                        //output.AppendLine("  ---Loss: " + visTeamGame.TeamRushLoss);
                        //output.AppendLine("  ---TD: " + visTeamGame.TeamRushTd);
                        //output.AppendLine("  ---Long: " + visTeamGame.TeamRushLong);
                    }

                    //passing
                    passNode = doc.SelectSingleNode("/fbgame/team[1]/totals/pass");

                    if (passNode != null)
                    {
                        reader.ReadToFollowing("pass");
                        reader.MoveToAttribute("comp");
                        //teamPassComp = reader.Value;
                        visTeamGame.passComp = Convert.ToDecimal(reader.Value);
                        reader.MoveToAttribute("att");
                        //teamPassAtt = reader.Value
                        visTeamGame.passAtt = Convert.ToDecimal(reader.Value);
                        reader.MoveToAttribute("int");
                        //teamPassInt = reader.Value;
                        visTeamGame.passInt = Convert.ToDecimal(reader.Value);
                        reader.MoveToAttribute("yds");
                        //teamPassYds = reader.Value;
                        visTeamGame.passYds = Convert.ToDecimal(reader.Value);
                        reader.MoveToAttribute("td");
                        //teamPassTd = reader.Value;
                        visTeamGame.passTd = Convert.ToDecimal(reader.Value);
                        reader.MoveToAttribute("long");
                        //teamPassLong = reader.Value;
                        visTeamGame.passLong = Convert.ToDecimal(reader.Value);
                        reader.MoveToAttribute("sacks");
                        //teamPassSacks = reader.Value;
                        visTeamGame.passSacks = Convert.ToDecimal(reader.Value);
                        reader.MoveToAttribute("sackyds");
                        //teamPassSackYds = reader.Value;
                        visTeamGame.passSackYds = Convert.ToDecimal(reader.Value);
                        //output.AppendLine("Passing: ");
                        //output.AppendLine("  ---Completions: " + visTeamGame.TeamPassComp);
                        //output.AppendLine("  ---Attempts: " + visTeamGame.TeamPassAtt);
                        //output.AppendLine("  ---Interceptions: " + visTeamGame.TeamPassInt);
                        //output.AppendLine("  ---Yds: " + visTeamGame.TeamPassYds);
                        //output.AppendLine("  ---TD: " + visTeamGame.TeamPassTd);
                        //output.AppendLine("  ---Long: " + visTeamGame.TeamPassLong);
                        //output.AppendLine("  ---Sacks: " + visTeamGame.TeamPassSacks);
                        //output.AppendLine("  ---Sack Yds: " + visTeamGame.TeamPassSackYds);
                    }

                    //receiving
                    rcvNode = doc.SelectSingleNode("/fbgame/team[1]/totals/rcv");

                    if (rcvNode != null)
                    {
                        reader.ReadToFollowing("rcv");
                        reader.MoveToAttribute("no");
                        //teamRcvNo = reader.Value;
                        visTeamGame.rcvNo = Convert.ToDecimal(reader.Value);
                        reader.MoveToAttribute("yds");
                        //teamRcvYds = reader.Value;
                        visTeamGame.rcvYds = Convert.ToDecimal(reader.Value);
                        reader.MoveToAttribute("td");
                        //teamRcvTd = reader.Value;
                        visTeamGame.rcvTd = Convert.ToDecimal(reader.Value);
                        reader.MoveToAttribute("long");
                        //teamRcvLong = reader.Value;
                        visTeamGame.rcvLong = Convert.ToDecimal(reader.Value);
                        //output.AppendLine("Receiving: ");
                        //output.AppendLine("  ---Number: " + visTeamGame.TeamRcvNo);
                        //output.AppendLine("  ---Yds: " + visTeamGame.TeamRcvYds);
                        //output.AppendLine("  ---TDs: " + visTeamGame.TeamRcvTd);
                        //output.AppendLine("  ---Long: " + visTeamGame.TeamRcvLong);
                    }

                    //punting
                    puntNode = doc.SelectSingleNode("/fbgame/team[1]/totals/punt");

                    if (puntNode != null)
                    {
                        reader.ReadToFollowing("punt");
                        reader.MoveToAttribute("no");
                        //teamPuntNo = reader.Value;
                        visTeamGame.puntNo = Convert.ToDecimal(reader.Value);
                        reader.MoveToAttribute("yds");
                        //teamPuntYds = reader.Value;
                        visTeamGame.puntYds = Convert.ToDecimal(reader.Value);
                        reader.MoveToAttribute("long");
                        //teamPuntLong = reader.Value;
                        visTeamGame.puntLong = Convert.ToDecimal(reader.Value);
                        reader.MoveToAttribute("blkd");
                        //teamPuntBlkd = reader.Value;
                        visTeamGame.puntBlkd = Convert.ToDecimal(reader.Value);
                        reader.MoveToAttribute("tb");
                        //teamPuntTb = reader.Value;
                        visTeamGame.puntTb = Convert.ToDecimal(reader.Value);
                        reader.MoveToAttribute("fc");
                        //teamPuntFc = reader.Value;
                        visTeamGame.puntFc = Convert.ToDecimal(reader.Value);
                        reader.MoveToAttribute("plus50");
                        //teamPuntPlus50 = reader.Value;
                        visTeamGame.puntPlus50 = Convert.ToDecimal(reader.Value);
                        reader.MoveToAttribute("inside20");
                        //teamPuntInside20 = reader.Value;
                        visTeamGame.puntInside20 = Convert.ToDecimal(reader.Value);

                        //output.AppendLine("Punting: ");
                        //output.AppendLine("  ---Number: " + visTeamGame.TeamPuntNo);
                        //output.AppendLine("  ---Yds: " + visTeamGame.TeamPuntYds);

                        //output.AppendLine("  ---Long: " + visTeamGame.TeamPuntLong);

                        //output.AppendLine("  ---Punts Blocked: " + visTeamGame.TeamPuntBlkd);
                        //output.AppendLine("  ---Punts TB?: " + visTeamGame.TeamPuntTb);
                        //output.AppendLine("  ---Punts Fc: " + visTeamGame.TeamPuntFc);
                        //output.AppendLine("  ---Punts plus50: " + visTeamGame.TeamPuntPlus50);
                        //output.AppendLine("  ---Punts inside the 20: " + visTeamGame.TeamPuntInside20);
                    }

                    //ko
                    koNode = doc.SelectSingleNode("/fbgame/team[1]/totals/ko");

                    if (koNode != null)
                    {
                        reader.ReadToFollowing("ko");
                        reader.MoveToAttribute("no");
                        //teamKoAtt = reader.Value;
                        visTeamGame.koNo = Convert.ToDecimal(reader.Value);
                        reader.MoveToAttribute("yds");
                        //teamKoYds = reader.Value;
                        visTeamGame.koYds = Convert.ToDecimal(reader.Value);
                        reader.MoveToAttribute("ob");
                        //teamKoOb = reader.Value;
                        visTeamGame.koOb = Convert.ToDecimal(reader.Value);
                        reader.MoveToAttribute("tb");
                        //teamKoTb = reader.Value;
                        visTeamGame.koTb = Convert.ToDecimal(reader.Value);
                        //output.AppendLine("Kickoffs: ");
                        //output.AppendLine("  ---Kickoff Attempts: " + visTeamGame.TeamKoAtt);
                        //output.AppendLine("  ---Kickoff Yards: " + visTeamGame.TeamKoYds);
                        //output.AppendLine("  ---Kickoffs OB: " + visTeamGame.TeamKoOb);
                        //output.AppendLine("  ---Touchbacks: " + visTeamGame.TeamKoTb);
                    }


                    //fg
                    fgNode = doc.SelectSingleNode("/fbgame/team[1]/totals/fg");

                    if (fgNode != null)
                    {
                        reader.ReadToFollowing("fg");
                        reader.MoveToAttribute("att");
                        visTeamGame.fgAtt = Convert.ToDecimal(reader.Value);
                        reader.MoveToAttribute("long");
                        visTeamGame.fgLong = Convert.ToDecimal(reader.Value);
                        reader.MoveToAttribute("blkd");
                        visTeamGame.fgBlkd = Convert.ToDecimal(reader.Value);
                        reader.MoveToAttribute("made");
                        visTeamGame.fgMade = Convert.ToDecimal(reader.Value);
                    }

                    //pat
                    patNode = doc.SelectSingleNode("/fbgame/team[1]/totals/pat");

                    if (patNode != null)
                    {
                        reader.ReadToFollowing("pat");

                        reader.MoveToFirstAttribute();

                        for (int y = 0; y < patNode.Attributes.Count; y++)
                        {
                            if (reader.Name == "kickatt")
                            {
                                visTeamGame.patKickAtt = Convert.ToDecimal(reader.Value);
                            }

                            if (reader.Name == "kickmade")
                            {
                                visTeamGame.patKickMade = Convert.ToDecimal(reader.Value);
                            }

                            if (reader.Name == "passatt")
                            {
                                visTeamGame.patPassAtt = Convert.ToDecimal(reader.Value);
                            }

                            if (reader.Name == "passmade")
                            {
                                visTeamGame.patPassMade = Convert.ToDecimal(reader.Value);
                            }

                            if (reader.Name == "rushatt")
                            {
                                visTeamGame.patRushAtt = Convert.ToDecimal(reader.Value);
                            }

                            if (reader.Name == "rushmade")
                            {
                                visTeamGame.patRushMade = Convert.ToDecimal(reader.Value);
                            }

                            reader.MoveToNextAttribute();
                        }
                        //output.AppendLine("PAT: ");
                        //output.AppendLine("  ---PAT Attempts: " + visTeamGame.TeamPatAtt);
                        //output.AppendLine("  ---PAT Made: " + visTeamGame.TeamPatMade);
                    }

                    //defense
                    defenseNode = doc.SelectSingleNode("/fbgame/team[1]/totals/defense");

                    if (defenseNode != null)
                    {
                        reader.ReadToFollowing("defense");

                        //output.AppendLine("Defense:");

                        reader.MoveToFirstAttribute();

                        for (int y = 0; y < defenseNode.Attributes.Count; y++)
                        {

                            if (reader.Name == "tackua")
                            {
                                //defTackUa = reader.Value;
                                visTeamGame.defTackUA = Convert.ToDecimal(reader.Value);
                                //output.AppendLine("  ---Tackles(UA): " + visTeamGame.TackUA);
                            }
                            if (reader.Name == "tacka")
                            {
                                //defTackA = reader.Value;
                                visTeamGame.defTackA = Convert.ToDecimal(reader.Value);
                                //output.AppendLine("  ---Tackles(A): " + visTeamGame.TackA);
                            }
                            if (reader.Name == "tflua")
                            {
                                //defTflUa = reader.Value;
                                visTeamGame.defTflUA = Convert.ToDecimal(reader.Value);
                                //output.AppendLine("  ---TFL(UA): " + visTeamGame.TflUA);
                            }
                            if (reader.Name == "tfla")
                            {
                                //defTflA = reader.Value;
                                visTeamGame.defTflA = Convert.ToDecimal(reader.Value);
                                //output.AppendLine("  ---TFL(A): " + visTeamGame.TflA);
                            }
                            if (reader.Name == "tflyds")
                            {
                                //defTflYds = reader.Value;
                                visTeamGame.defTflYards = Convert.ToDecimal(reader.Value);
                                //output.AppendLine("  ---TFL Yds: " + visTeamGame.TflYards);
                            }
                            if (reader.Name == "sacks")
                            {
                                //defSacks = reader.Value;
                                visTeamGame.defSacks = Convert.ToDecimal(reader.Value);
                                //output.AppendLine("  ---Sacks: " + visTeamGame.Sacks);
                            }
                            if (reader.Name == "sackyds")
                            {
                                //defSackYds = reader.Value;
                                visTeamGame.defSackYds = Convert.ToDecimal(reader.Value);
                                //output.AppendLine("  ---Sack Yds: " + visTeamGame.SackYds);
                            }
                            if (reader.Name == "brup")
                            {
                                //defBrup = reader.Value;
                                visTeamGame.defBrup = Convert.ToDecimal(reader.Value);
                                //output.AppendLine("  ---Pass Breakups: " + visTeamGame.Brup);
                            }
                            if (reader.Name == "qbh")
                            {
                                //defQbh = reader.Value;
                                visTeamGame.defQbh = Convert.ToDecimal(reader.Value);
                                //output.AppendLine("  ---QB Hurries: " + visTeamGame.Qbh);
                            }
                            if (reader.Name == "blkd")
                            {
                                //defBlkd = reader.Value;
                                visTeamGame.defBlkd = Convert.ToDecimal(reader.Value);
                                //output.AppendLine("  ---Kicks Blkd.: " + defBlkd);
                            }
                            if (reader.Name == "ff")
                            {
                                //defFf = reader.Value;
                                visTeamGame.defFF = Convert.ToDecimal(reader.Value);
                                //output.AppendLine("  ---Fumbles Forced: " + visTeamGame.FF);
                            }
                            if (reader.Name == "fr")
                            {
                                //defFr = reader.Value;
                                visTeamGame.defFR = Convert.ToDecimal(reader.Value);
                                //output.AppendLine("  ---Fumbles Recovered: " + visTeamGame.FR);
                            }
                            if (reader.Name == "int")
                            {
                                //defInt = reader.Value;
                                visTeamGame.defInts = Convert.ToDecimal(reader.Value);
                                //output.AppendLine("  ---Interceptions: " + visTeamGame.Ints);
                            }
                            if (reader.Name == "intyds")
                            {
                                //defIntYds = reader.Value;
                                visTeamGame.defIntYds = Convert.ToDecimal(reader.Value);
                                //output.AppendLine("  ---Int. Yds: " + visTeamGame.IntYds);
                            }

                            reader.MoveToNextAttribute();
                        }
                    }

                    //kr
                    krNode = doc.SelectSingleNode("/fbgame/team[1]/totals/kr");

                    if (krNode != null)
                    {
                        reader.ReadToFollowing("kr");
                        reader.MoveToAttribute("td");
                        //teamKrTd = reader.Value;
                        visTeamGame.krTd = Convert.ToDecimal(reader.Value);
                        reader.MoveToAttribute("yds");
                        //teamKrYds = reader.Value;
                        visTeamGame.krYds = Convert.ToDecimal(reader.Value);
                        reader.MoveToAttribute("no");
                        //teamKrNo = reader.Value;
                        visTeamGame.krNo = Convert.ToDecimal(reader.Value);
                        reader.MoveToAttribute("long");
                        //teamKrLong = reader.Value;
                        visTeamGame.krLong = Convert.ToDecimal(reader.Value);
                        //    output.AppendLine("Kick Returns: ");
                        //    output.AppendLine("  ---Kick Return TD: " + visTeamGame.TeamKrTd);
                        //    output.AppendLine("  ---Kick Return Yards: " + visTeamGame.TeamKrYds);
                        //    output.AppendLine("  ---Kick Return Attempts: " + visTeamGame.TeamKrNo);
                        //    output.AppendLine("  ---Kick Return Long: " + visTeamGame.TeamKrLong);
                    }

                    //pr
                    prNode = doc.SelectSingleNode("/fbgame/team[1]/totals/pr");

                    if (prNode != null)
                    {
                        reader.ReadToFollowing("pr");
                        reader.MoveToAttribute("td");
                        //teamPrTd = reader.Value;
                        visTeamGame.prTd = Convert.ToDecimal(reader.Value);
                        reader.MoveToAttribute("yds");
                        //teamPrYds = reader.Value;
                        visTeamGame.prYds = Convert.ToDecimal(reader.Value);
                        reader.MoveToAttribute("no");
                        //teamPrNo = reader.Value;
                        visTeamGame.prNo = Convert.ToDecimal(reader.Value);
                        reader.MoveToAttribute("long");
                        //teamPrLong = reader.Value;
                        visTeamGame.prLong = Convert.ToDecimal(reader.Value);
                        //output.AppendLine("Punt Returns: ");
                        //output.AppendLine("  ---Punt Return TD: " + visTeamGame.TeamPrTd);
                        //output.AppendLine("  ---Punt Return Yards: " + visTeamGame.TeamPrYds);
                        //output.AppendLine("  ---Punt Return Attempts: " + visTeamGame.TeamPrNo);
                        //output.AppendLine("  ---Punt Return Long: " + visTeamGame.TeamPrLong);
                    }

                    //ir
                    irNode = doc.SelectSingleNode("/fbgame/team[1]/totals/ir");

                    if (irNode != null)
                    {
                        reader.ReadToFollowing("ir");
                        reader.MoveToAttribute("td");
                        //teamIrTd = reader.Value;
                        visTeamGame.irTd = Convert.ToDecimal(reader.Value);
                        reader.MoveToAttribute("yds");
                        //teamIrYds = reader.Value;
                        visTeamGame.irYds = Convert.ToDecimal(reader.Value);
                        reader.MoveToAttribute("no");
                        // teamIrNo = reader.Value;
                        visTeamGame.irNo = Convert.ToDecimal(reader.Value);
                        reader.MoveToAttribute("long");
                        //teamIrLong = reader.Value;
                        visTeamGame.irLong = Convert.ToDecimal(reader.Value);
                        //output.AppendLine("Interception Returns: ");
                        //output.AppendLine("  ---Int Return TD: " + visTeamGame.TeamIrTd);
                        //output.AppendLine("  ---Int Return Yards: " + visTeamGame.TeamIrYds);
                        //output.AppendLine("  ---Int Return Attempts: " + visTeamGame.TeamIrNo);
                        //output.AppendLine("  ---Int Return Long: " + visTeamGame.TeamIrLong);
                    }

                    //scoring
                    scoringNode = doc.SelectSingleNode("/fbgame/team[1]/totals/scoring");

                    if (scoringNode != null)
                    {
                        reader.ReadToFollowing("scoring");
                        output.AppendLine("Scoring:");

                        reader.MoveToFirstAttribute();

                        for (int y = 0; y < scoringNode.Attributes.Count; y++)
                        {

                            if (reader.Name == "td")
                            {
                                //scoringTd = reader.Value;
                                visTeamGame.scoringTD = Convert.ToDecimal(reader.Value);
                                //output.AppendLine("  ---TD: " + visTeamGame.TD);
                            }
                            if (reader.Name == "fg")
                            {
                                //scoringFg = reader.Value;
                                visTeamGame.scoringFG = Convert.ToDecimal(reader.Value);
                                //output.AppendLine("  ---FG: " + visTeamGame.FG);
                            }
                            if (reader.Name == "patkick")
                            {
                                //scoringPatKick = reader.Value;
                                visTeamGame.scoringPatKick = Convert.ToDecimal(reader.Value);
                                //output.AppendLine("  ---PAT Kick: " + visTeamGame.PatKick);
                            }
                            if (reader.Name == "patrush")
                            {
                                //scoringPatRush = reader.Value;
                                visTeamGame.scoringPatRush = Convert.ToDecimal(reader.Value);
                                //output.AppendLine("  ---PAT Rush: " + visTeamGame.PatRush);
                            }
                            if (reader.Name == "patrcv")
                            {
                                //scoringPatRcv = reader.Value;
                                visTeamGame.scoringPatRcv = Convert.ToDecimal(reader.Value);
                                //output.AppendLine("  ---PAT Rcv: " + visTeamGame.PatRcv);
                            }
                            if (reader.Name == "saf")
                            {
                                //scoringSaf = reader.Value;
                                visTeamGame.scoringSaf = Convert.ToDecimal(reader.Value);
                                //output.AppendLine("  ---Safeties: " + visTeamGame.Saf);
                            }

                            reader.MoveToNextAttribute();
                        }
                    }

                    try
                    {
                        findVisTeam = db.Teams.Single(x => x.name == visTeamGame.teamName);
                    }
                    catch (Exception e)
                    {

                    }

                    if (findVisTeam.name == null)
                    {
                        Team newTeam = new Team();
                        newTeam.name = visTeamGame.teamName;
                        db.Teams.Add(newTeam);
                        db.SaveChanges();
                        visTeamGame.team_Id = newTeam.team_Id;
                    }

                    if (findVisTeam.name != null)
                    {
                        visTeamGame.team_Id = findVisTeam.team_Id;
                    }

                    visTeamGame.game_Id = game.game_Id;

                    db.TeamGames.Add(visTeamGame);
                    db.SaveChanges();

                    visLinescore.teamGame_Id = visTeamGame.teamGame_Id;

                    db.Linescores.Add(visLinescore);
                    db.SaveChanges();

                    foreach (var l in visLineprds)
                    {
                        l.linescore_Id = visLinescore.linescore_Id;

                        db.Lineprds.Add(l);
                    }
                    db.SaveChanges();

                    #region players
                    //player

                    if (visTeamGame.teamName == "Alabama" || visTeamGame.teamName == "Alabama Crimson Tide" || visTeamGame.teamName == "ALABAMA" || visTeamGame.teamName == "UA")
                    {
                        //output.AppendLine("Players: ");

                        int playerCount = teamNode.ChildNodes.Count - 1;
                        int i = 1;
                        do
                        {
                            playerGame = new PlayerGame(); 

                            playerNode = doc.SelectSingleNode("/fbgame/team[1]/player[" + i + "]");
                            reader.ReadToFollowing("player");

                            reader.MoveToAttribute("name");
                            playerName = reader.Value;
                            reader.MoveToAttribute("uni");
                            playerGame.uni = reader.Value;
                            reader.MoveToAttribute("class");
                            playerGame.@class = reader.Value;
                            

                            for (int y = 0; y < playerNode.Attributes.Count; y++)
                            {
                                if (playerNode.Attributes[y].Name == "gp")
                                {
                                    reader.MoveToAttribute("gp");
                                    playerGame.gp = reader.Value;
                                }

                                if (playerNode.Attributes[y].Name == "gs")
                                {
                                    reader.MoveToAttribute("gs");
                                    playerGame.gs = reader.Value;
                                }

                                if (playerNode.Attributes[y].Name == "opos")
                                {
                                    reader.MoveToAttribute("opos");
                                    playerGame.oPos = reader.Value;
                                }

                                if (playerNode.Attributes[y].Name == "dpos")
                                {
                                    reader.MoveToAttribute("dpos");
                                    playerGame.dPos = reader.Value;
                                }
                            }

                            playerGame.playerGame_Id = playerName + playerGame.uni + playerGame.@class + game.date_;

                            //output.AppendLine("  " + playerId + " " + playerName + " #" + playerUni + " " + playerPos + ", " + playerClass);

                            if (playerNode.HasChildNodes)
                            {
                                for (int x = 0; x < playerNode.ChildNodes.Count; x++)
                                {
                                    reader.ReadToFollowing(playerNode.ChildNodes[x].Name);

                                    //rushing
                                    if (reader.Name == "rush")
                                    {
                                        rush = new Rush();

                                        //output.AppendLine("    Rush");
                                        reader.MoveToAttribute("att");
                                        rush.att = Convert.ToDecimal(reader.Value);
                                        //output.AppendLine("      Att: " + rushAtt);
                                        reader.MoveToAttribute("yds");
                                        rush.yds = Convert.ToDecimal(reader.Value);
                                        //output.AppendLine("      Yds: " + rushYds);
                                        reader.MoveToAttribute("gain");
                                        rush.gain = Convert.ToDecimal(reader.Value);
                                        //output.AppendLine("      Gain: " + rushGain);
                                        reader.MoveToAttribute("loss");
                                        rush.loss = Convert.ToDecimal(reader.Value);
                                        //output.AppendLine("      Loss: " + rushLoss);
                                        reader.MoveToAttribute("td");
                                        rush.td = Convert.ToDecimal(reader.Value);
                                        //output.AppendLine("      TD: " + rushTd);
                                        reader.MoveToAttribute("long");
                                        rush.@long = Convert.ToDecimal(reader.Value);
                                        //output.AppendLine("      Long: " + rushLong);
                                        rush.playerGame_Id = playerGame.playerGame_Id;
                                    }

                                    //passing
                                    if (reader.Name == "pass")
                                    {
                                        pass = new Pass();

                                        //output.AppendLine("    Pass");
                                        reader.MoveToAttribute("comp");
                                        pass.comp = Convert.ToDecimal(reader.Value);
                                        //output.AppendLine("      Comp: " + passComp);
                                        reader.MoveToAttribute("att");
                                        pass.att = Convert.ToDecimal(reader.Value);
                                        //output.AppendLine("      Att: " + passAtt);
                                        reader.MoveToAttribute("int");
                                        pass.int_ = Convert.ToDecimal(reader.Value);
                                        //output.AppendLine("      Int: " + passInt);
                                        reader.MoveToAttribute("yds");
                                        pass.yds = Convert.ToDecimal(reader.Value);
                                        //output.AppendLine("      Yds: " + passYds);
                                        reader.MoveToAttribute("td");
                                        pass.td = Convert.ToDecimal(reader.Value);
                                        //output.AppendLine("      TD: " + passTd);
                                        reader.MoveToAttribute("long");
                                        pass.@long = Convert.ToDecimal(reader.Value);
                                        //output.AppendLine("      Long: " + passLong);
                                        reader.MoveToAttribute("sacks");
                                        pass.sacks = Convert.ToDecimal(reader.Value);
                                        //output.AppendLine("      Sacks: " + passSacks);
                                        reader.MoveToAttribute("sackyds");
                                        pass.sackYds = Convert.ToDecimal(reader.Value);
                                        //output.AppendLine("      SackYds: " + passSackYds);
                                        pass.playerGame_Id = playerGame.playerGame_Id;
                                    }

                                    //receiving
                                    if (reader.Name == "rcv")
                                    {
                                        rcv = new Rcv();

                                        //output.AppendLine("    Receiving");
                                        reader.MoveToAttribute("no");
                                        rcv.no_ = Convert.ToDecimal(reader.Value);
                                        //output.AppendLine("      No: " + rcvNo);
                                        reader.MoveToAttribute("yds");
                                        rcv.yds = Convert.ToDecimal(reader.Value);
                                        //output.AppendLine("      Yards: " + rcvYds);
                                        reader.MoveToAttribute("td");
                                        rcv.td = Convert.ToDecimal(reader.Value);
                                        //output.AppendLine("      TD: " + rcvTd);
                                        reader.MoveToAttribute("long");
                                        rcv.@long = Convert.ToDecimal(reader.Value);
                                        //output.AppendLine("      Long: " + rcvLong);
                                        rcv.playerGame_Id = playerGame.playerGame_Id;
                                    }

                                    //punting
                                    if (reader.Name == "punt")
                                    {
                                        punt = new Punt();

                                        //output.AppendLine("    Punt");
                                        reader.MoveToAttribute("yds");
                                        punt.yds_ = Convert.ToDecimal(reader.Value);
                                        //output.AppendLine("      Yds: " + puntYds);
                                        reader.MoveToAttribute("no");
                                        punt.no_ = Convert.ToDecimal(reader.Value);
                                        //output.AppendLine("      Att: " + puntNo);
                                        reader.MoveToAttribute("long");
                                        punt.long_ = Convert.ToDecimal(reader.Value);
                                        //output.AppendLine("      Long: " + puntLong);
                                        reader.MoveToAttribute("inside20");
                                        punt.inside20 = Convert.ToDecimal(reader.Value);
                                        //output.AppendLine("      Inside 20: " + puntInside20);
                                        reader.MoveToAttribute("plus50");
                                        punt.plus50 = Convert.ToDecimal(reader.Value);
                                        //output.AppendLine("      Plus 50: " + puntPlus50);
                                        reader.MoveToAttribute("fc");
                                        punt.fc = Convert.ToDecimal(reader.Value);
                                        //output.AppendLine("      Fair Catch: " + puntFc);
                                        reader.MoveToAttribute("tb");
                                        punt.tb = Convert.ToDecimal(reader.Value);
                                        //output.AppendLine("      Touchbacks: " + puntTb);
                                        reader.MoveToAttribute("blkd");
                                        punt.blkd_ = Convert.ToDecimal(reader.Value);
                                        //output.AppendLine("      Blocked: " + puntBlkd);
                                        punt.playerGame_Id = playerGame.playerGame_Id;
                                    }

                                    //kickoff
                                    if (reader.Name == "ko")
                                    {
                                        ko = new Ko();

                                        //output.AppendLine("    KO");
                                        reader.MoveToAttribute("no");
                                        ko.no_ = Convert.ToDecimal(reader.Value);
                                        //output.AppendLine("      KO Att: " + koAtt);
                                        reader.MoveToAttribute("yds");
                                        ko.yds = Convert.ToDecimal(reader.Value);
                                        //output.AppendLine("      KO Yds: " + koYds);
                                        reader.MoveToAttribute("ob");
                                        ko.ob = Convert.ToDecimal(reader.Value);
                                        //output.AppendLine("      # Out of bounds: " + koOb);
                                        reader.MoveToAttribute("tb");
                                        ko.tb = Convert.ToDecimal(reader.Value);
                                        //output.AppendLine("      Touchbacks: " + touchbacks);
                                        ko.playerGame_Id = playerGame.playerGame_Id;
                                    }

                                    //field goals
                                    if (reader.Name == "fg")
                                    {
                                        fg = new Fg();

                                        //output.AppendLine("    FG");
                                        reader.MoveToAttribute("att");
                                        fg.att = Convert.ToDecimal(reader.Value);
                                        //output.AppendLine("      FG Att: " + fgAtt);
                                        reader.MoveToAttribute("long");
                                        fg.@long = Convert.ToDecimal(reader.Value);
                                        //output.AppendLine("      FG Long: " + fgLong);
                                        reader.MoveToAttribute("blkd");
                                        fg.blkd = Convert.ToDecimal(reader.Value);
                                        //output.AppendLine("      FG Blocked: " + fgBlkd);
                                        reader.MoveToAttribute("made");
                                        fg.made = Convert.ToDecimal(reader.Value);
                                        //output.AppendLine("      FG Made: " + fgMade);
                                        fg.playerGame_Id = playerGame.playerGame_Id;
                                    }

                                    //PAT
                                    if (reader.Name == "pat")
                                    {
                                        patNode = doc.SelectSingleNode("/fbgame/team[1]/player[" + i + "]/pat");

                                        pat = new Pat();

                                        reader.MoveToFirstAttribute();

                                        for (int y = 0; y < patNode.Attributes.Count; y++)
                                        {
                                            if (reader.Name == "kickatt")
                                            {
                                                pat.kickAtt = Convert.ToDecimal(reader.Value);
                                            }

                                            if (reader.Name == "kickmade")
                                            {
                                                pat.kickMade = Convert.ToDecimal(reader.Value);
                                            }

                                            if (reader.Name == "passatt")
                                            {
                                                pat.passAtt = Convert.ToDecimal(reader.Value);
                                            }

                                            if (reader.Name == "passmade")
                                            {
                                                pat.passMade = Convert.ToDecimal(reader.Value);
                                            }

                                            if (reader.Name == "rushatt")
                                            {
                                                pat.rushAtt = Convert.ToDecimal(reader.Value);
                                            }

                                            if (reader.Name == "rushmade")
                                            {
                                                pat.rushMade = Convert.ToDecimal(reader.Value);
                                            }

                                            reader.MoveToNextAttribute();
                                        }
                                        pat.playerGame_Id = playerGame.playerGame_Id;
                                    }

                                    //defense
                                    if (reader.Name == "defense")
                                    {
                                        defenseNode = doc.SelectSingleNode("/fbgame/team[1]/player[" + i + "]/defense");
                                        //output.AppendLine("    Defense");

                                        defense = new Defense();

                                        reader.MoveToFirstAttribute();

                                        for (int y = 0; y < defenseNode.Attributes.Count; y++)
                                        {

                                            if (reader.Name == "tackua")
                                            {
                                                defense.tackUA = Convert.ToDecimal(reader.Value);
                                                //output.AppendLine("      Tackles(UA): " + defTackUa);
                                            }
                                            if (reader.Name == "tacka")
                                            {
                                                defense.tackA = Convert.ToDecimal(reader.Value);
                                                //output.AppendLine("      Tackles(A): " + defTackA);
                                            }
                                            if (reader.Name == "tflua")
                                            {
                                                defense.tflUA = Convert.ToDecimal(reader.Value);
                                                //output.AppendLine("      TFL(UA): " + defTflUa);
                                            }
                                            if (reader.Name == "tfla")
                                            {
                                                defense.tflA = Convert.ToDecimal(reader.Value);
                                                //output.AppendLine("      TFL(A): " + defTflA);
                                            }
                                            if (reader.Name == "tflyds")
                                            {
                                                defense.tflYds = Convert.ToDecimal(reader.Value);
                                                //output.AppendLine("      TFL Yds: " + defTflYds);
                                            }
                                            if (reader.Name == "sacks")
                                            {
                                                defense.sacks = Convert.ToDecimal(reader.Value);
                                                //output.AppendLine("      Sacks: " + defSacks);
                                            }
                                            if (reader.Name == "sackyds")
                                            {
                                                defense.sackYds = Convert.ToDecimal(reader.Value);
                                                //output.AppendLine("      Sack Yds: " + defSackYds);
                                            }
                                            if (reader.Name == "brup")
                                            {
                                                defense.brup = Convert.ToDecimal(reader.Value);
                                                //output.AppendLine("      Pass Breakups: " + defBrup);
                                            }
                                            if (reader.Name == "qbh")
                                            {
                                                defense.qbh = Convert.ToDecimal(reader.Value);
                                                //output.AppendLine("      QB Hurries: " + defQbh);
                                            }
                                            if (reader.Name == "blkd")
                                            {
                                                defense.blkd = Convert.ToDecimal(reader.Value);
                                                //output.AppendLine("      Kicks Blkd.: " + defBlkd);
                                            }
                                            if (reader.Name == "ff")
                                            {
                                                defense.ff = Convert.ToDecimal(reader.Value);
                                                //output.AppendLine("      Fumbles Forced: " + defFf);
                                            }
                                            if (reader.Name == "fr")
                                            {
                                                defense.fr = Convert.ToDecimal(reader.Value);
                                                //output.AppendLine("      Fumbles Recovered: " + defFr);
                                            }
                                            if (reader.Name == "fryds")
                                            {
                                                defense.frYds = Convert.ToDecimal(reader.Value);
                                                //output.AppendLine("      Fumb. Rec. Yds: " + defFrYds);
                                            }
                                            if (reader.Name == "int")
                                            {
                                                defense.ints = Convert.ToDecimal(reader.Value);
                                                //output.AppendLine("      Interceptions: " + defInt);
                                            }
                                            if (reader.Name == "intyds")
                                            {
                                                defense.intYds = Convert.ToDecimal(reader.Value);
                                                //output.AppendLine("      Int. Yds: " + defIntYds);
                                            }

                                            reader.MoveToNextAttribute();
                                        }
                                        
                                        defense.playerGame_Id = playerGame.playerGame_Id;
                                    }

                                    //fumbles
                                    if (reader.Name == "fumbles")
                                    {
                                        fumble = new Fumble();

                                        //output.AppendLine("    Fumbles");
                                        reader.MoveToAttribute("no");
                                        fumble.no_ = reader.Value;
                                        //output.AppendLine("      Fumbles: " + fumbles);
                                        reader.MoveToAttribute("lost");
                                        fumble.lost = reader.Value;
                                        //output.AppendLine("      Lost: " + fumblesLost);
                                        fumble.playerGame_Id = playerGame.playerGame_Id;
                                    }

                                    //kick returns
                                    if (reader.Name == "kr")
                                    {
                                        kr = new Kr();

                                        //output.AppendLine("    Kick Returns");
                                        reader.MoveToAttribute("td");
                                        kr.td = Convert.ToDecimal(reader.Value);
                                        //output.AppendLine("     Touchdowns: " + krTd);
                                        reader.MoveToAttribute("yds");
                                        kr.yds_ = Convert.ToDecimal(reader.Value);
                                        //output.AppendLine("     Yards: " + krYds);
                                        reader.MoveToAttribute("no");
                                        kr.no_ = Convert.ToDecimal(reader.Value);
                                        //output.AppendLine("     Attempts: " + krNo);
                                        reader.MoveToAttribute("long");
                                        kr.@long = Convert.ToDecimal(reader.Value);
                                        //output.AppendLine("     Long: " + krLong);
                                        kr.playerGame_Id = playerGame.playerGame_Id;
                                    }

                                    //punt returns
                                    if (reader.Name == "pr")
                                    {
                                        pr = new Pr();

                                        //output.AppendLine("    Punt Returns");
                                        reader.MoveToAttribute("td");
                                        pr.td = Convert.ToDecimal(reader.Value);
                                        //output.AppendLine("     Touchdowns: " + prTd);
                                        reader.MoveToAttribute("yds");
                                        pr.yds = Convert.ToDecimal(reader.Value);
                                        //output.AppendLine("     Yards: " + prYds);
                                        reader.MoveToAttribute("no");
                                        pr.no_ = Convert.ToDecimal(reader.Value);
                                        //output.AppendLine("     Attempts: " + prNo);
                                        reader.MoveToAttribute("long");
                                        pr.@long = Convert.ToDecimal(reader.Value);
                                        //output.AppendLine("     Long: " + prLong);
                                        pr.playerGame_Id = playerGame.playerGame_Id;
                                    }

                                    //interceptions
                                    if (reader.Name == "ir")
                                    {
                                        ir = new Ir();

                                        //output.AppendLine("    Interceptions");
                                        reader.MoveToAttribute("td");
                                        ir.td = Convert.ToDecimal(reader.Value);
                                        //output.AppendLine("     Touchdowns: " + irTd);
                                        reader.MoveToAttribute("yds");
                                        ir.yds = Convert.ToDecimal(reader.Value);
                                        //output.AppendLine("     Yards: " + irYds);
                                        reader.MoveToAttribute("no");
                                        ir.no_ = Convert.ToDecimal(reader.Value);
                                        //output.AppendLine("     Attempts: " + irNo);
                                        reader.MoveToAttribute("long");
                                        ir.@long = Convert.ToDecimal(reader.Value);
                                        //output.AppendLine("     Long: " + irLong);
                                        ir.playerGame_Id = playerGame.playerGame_Id;
                                    }

                                    //scoring
                                    if (reader.Name == "scoring")
                                    {
                                        scoringNode = doc.SelectSingleNode("/fbgame/team[1]/player[" + i + "]/scoring");
                                        //output.AppendLine("    Scoring");

                                        scoring = new Scoring();

                                        reader.MoveToFirstAttribute();

                                        for (int y = 0; y < scoringNode.Attributes.Count; y++)
                                        {

                                            if (reader.Name == "td")
                                            {
                                                scoring.td = Convert.ToDecimal(reader.Value);
                                                //output.AppendLine("      TD: " + scoringTd);
                                            }
                                            if (reader.Name == "fg")
                                            {
                                                scoring.fg = Convert.ToDecimal(reader.Value);
                                                //output.AppendLine("      FG: " + scoringFg);
                                            }
                                            if (reader.Name == "patkick")
                                            {
                                                scoring.kick = Convert.ToDecimal(reader.Value);
                                                //output.AppendLine("      PAT Kick: " + scoringPatKick);
                                            }
                                            if (reader.Name == "patrush")
                                            {
                                                scoring.rush = Convert.ToDecimal(reader.Value);
                                                //output.AppendLine("      PAT Rush: " + scoringPatRush);
                                            }
                                            if (reader.Name == "patrcv")
                                            {
                                                scoring.rcv = Convert.ToDecimal(reader.Value);
                                                //output.AppendLine("      PAT Rcv: " + scoringPatRcv);
                                            }
                                            if (reader.Name == "saf")
                                            {
                                                scoring.saf = Convert.ToDecimal(reader.Value);
                                                //output.AppendLine("      Safeties: " + scoringSaf);
                                            }

                                            reader.MoveToNextAttribute();
                                        }
                                        scoring.playerGame_Id = playerGame.playerGame_Id;
                                    }

                                }
                            }

                            playerGame.game_Id = game.game_Id;

                            try
                            {
                                findPlayer =  db.Players.Single(x => x.name == playerName);
                            }
                            catch (Exception e)
                            {

                            }
                            

                            

                            if (findPlayer.name == null)
                            {
                                player = new Player();

                                player.name = playerName;
                                player.firstGame = Convert.ToDateTime(game.date_);
                                player.lastGame = Convert.ToDateTime(game.date_);
                                player.player_Id = playerName + "-" + game.date_;
                                playerGame.player_Id = player.player_Id;

                                db.Players.Add(player);
                                db.SaveChanges();
                            }

                            if (findPlayer.name != null)
                            {
                                gameDate = Convert.ToDateTime(game.date_);
                                lastGame = Convert.ToDateTime(findPlayer.lastGame);

                                ts = (gameDate - lastGame);

                                yearsSince = ts.Days / 365;

                                if (yearsSince <= 5)
                                {
                                    playerGame.player_Id = findPlayer.player_Id;

                                    if (findPlayer.lastGame < gameDate)
                                    {
                                        findPlayer.lastGame = gameDate;
                                    }

                                    db.SaveChanges();
                                }
                                else
                                {
                                    player = new Player();

                                    player.name = playerName;
                                    player.firstGame = gameDate;
                                    player.lastGame = gameDate;
                                    player.player_Id = playerName + "-" + game.date_;
                                    playerGame.player_Id = player.player_Id;

                                    db.Players.Add(player);
                                    db.SaveChanges();
                                }
                            }

                            db.PlayerGames.Add(playerGame);
                            db.SaveChanges();

                            if (playerGame.playerGame_Id == rush.playerGame_Id)
                            {
                                db.Rushes.Add(rush);
                                db.SaveChanges();
                            }

                            if (playerGame.playerGame_Id == pass.playerGame_Id)
                            {
                                db.Passes.Add(pass);
                                db.SaveChanges();
                            }

                            if (playerGame.playerGame_Id == rcv.playerGame_Id)
                            {
                                db.Rcvs.Add(rcv);
                                db.SaveChanges();
                            }

                            if (playerGame.playerGame_Id == punt.playerGame_Id)
                            {
                                db.Punts.Add(punt);
                                db.SaveChanges();
                            }

                            if (playerGame.playerGame_Id == ko.playerGame_Id)
                            {
                                db.Koes.Add(ko);
                                db.SaveChanges();
                            }

                            if (playerGame.playerGame_Id == fg.playerGame_Id)
                            {
                                db.Fgs.Add(fg);
                                db.SaveChanges();
                            }

                            if (playerGame.playerGame_Id == pat.playerGame_Id)
                            {
                                db.Pats.Add(pat);
                                db.SaveChanges();
                            }

                            if (playerGame.playerGame_Id == kr.playerGame_Id)
                            {
                                db.Krs.Add(kr);
                                db.SaveChanges();
                            }

                            if (playerGame.playerGame_Id == pr.playerGame_Id)
                            {
                                db.Prs.Add(pr);
                                db.SaveChanges();
                            }

                            if (playerGame.playerGame_Id == ir.playerGame_Id)
                            {
                                db.Irs.Add(ir);
                                db.SaveChanges();
                            }

                            if (playerGame.playerGame_Id == scoring.playerGame_Id)
                            {
                                db.Scorings.Add(scoring);
                                db.SaveChanges();
                            }

                            if (playerGame.playerGame_Id == defense.playerGame_Id)
                            {
                                db.Defenses.Add(defense);
                                db.SaveChanges();
                            }

                            if (playerGame.playerGame_Id == fumble.playerGame_Id)
                            {
                                db.Fumbles.Add(fumble);
                                db.SaveChanges();
                            }

                            i++;
                        } while (i < playerCount);
                    }
                    #endregion
                    #endregion

                    #region home team
                    //hometeam
                    teamNode = doc.SelectSingleNode("/fbgame/team[2]");

                    reader.ReadToFollowing("team");
                    reader.MoveToAttribute("name");
                    homeTeamGame.teamName = reader.Value;
                    //output.AppendLine("Visitor: " + teamname);

                    reader.MoveToAttribute("vh");
                    homeTeamGame.vh = reader.Value;

                    reader.MoveToAttribute("code");
                    homeTeamGame.code = reader.Value;

                    reader.MoveToAttribute("record");
                    homeTeamGame.record = reader.Value;
                    //output.AppendLine("  ----Record: " + homeTeamGame.record);

                    reader.MoveToAttribute("conf-record");
                    homeTeamGame.confRecord = reader.Value;

                    reader.MoveToAttribute("abb");
                    homeTeamGame.abb = reader.Value;
                    
                    flag = false;

                    for (int x = 0; x < teamNode.Attributes.Count; x++)
                    {
                        if (teamNode.Attributes[x].Name == "rank")
                        {
                            reader.MoveToAttribute("rank");
                            homeTeamGame.rank_ = reader.Value;
                            //output.AppendLine("  ----Ranking: " + rank);
                            flag = true;
                        }
                    }

                    if (flag == false)
                    {
                        homeTeamGame.rank_ = "NR";
                        //output.AppendLine("  ----Ranking: " + rank);
                    }

                    //linescore
                    homeLinescore = new Linescore();
                    
                    reader.ReadToFollowing("linescore");
                    reader.MoveToAttribute("prds");
                    homeLinescore.prds = Convert.ToDecimal(reader.Value);
                    //output.AppendLine("Periods: " + prds);
                    reader.MoveToAttribute("line");
                    homeLinescore.line = reader.Value;
                    //output.AppendLine("Line: " + line);
                    reader.MoveToAttribute("score");
                    homeLinescore.score = Convert.ToDecimal(reader.Value);
                    
                    //output.AppendLine("Score: " + score);

                    //lineprd (each)
                    lineprd = new Lineprd();

                    reader.ReadToFollowing("lineprd");
                    reader.MoveToAttribute("prd");
                    lineprd.prd = Convert.ToDecimal(reader.Value);
                    reader.MoveToAttribute("score");
                    lineprd.score = Convert.ToDecimal(reader.Value);

                    homeLineprds.Add(lineprd);
                    //output.AppendLine("  " + prd + ": " + prdscore);
                    while (reader.ReadToNextSibling("lineprd"))
                    {
                        lineprd = new Lineprd();

                        reader.MoveToAttribute("prd");
                        lineprd.prd = Convert.ToDecimal(reader.Value);
                        reader.MoveToAttribute("score");
                        lineprd.score = Convert.ToDecimal(reader.Value);

                        homeLineprds.Add(lineprd);
                        //output.AppendLine("  " + prd + ": " + prdscore);
                    }

                    
                    //totals
                    reader.ReadToFollowing("totals");
                    //reader.MoveToFirstAttribute();
                    //teamTotOffPlays = reader.Value;
                    //output.AppendLine("Total Plays: " + teamTotOffPlays);
                    //reader.MoveToNextAttribute();
                    //teamTotOffYards = reader.Value;
                    //output.AppendLine("Total Yards: " + teamTotOffYards);
                    //reader.MoveToNextAttribute();
                    //teamTotOffAvg = reader.Value;
                    //output.AppendLine("Yds/Play: " + teamTotOffAvg);

                    //first downs
                    firstDownNode = doc.SelectSingleNode("/fbgame/team[2]/totals/firstdowns");
                    if(firstDownNode != null)
                    {
                        reader.ReadToFollowing("firstdowns");
                        reader.MoveToAttribute("no");
                        //teamFirstDownNo = reader.Value;
                        homeTeamGame.firstDownNo = Convert.ToDecimal(reader.Value);
                        //output.AppendLine("First Downs: " + homeTeamGame.TeamFirstDownNo);
                        reader.MoveToAttribute("rush");
                        //teamFirstDownRush = reader.Value;
                        homeTeamGame.firstDownRush = Convert.ToDecimal(reader.Value);
                        //output.AppendLine("   ----Rush: " + homeTeamGame.TeamFirstDownRush);
                        reader.MoveToAttribute("pass");
                        //teamFirstDownPass = reader.Value;
                        homeTeamGame.firstDownPass = Convert.ToDecimal(reader.Value);
                        //output.AppendLine("   ----Pass: " + homeTeamGame.TeamFirstDownPass);
                        reader.MoveToAttribute("penalty");
                        //teamFirstDownPen = reader.Value;
                        homeTeamGame.firstDownPen = Convert.ToDecimal(reader.Value);
                        //output.AppendLine("   ----Penalty: " + homeTeamGame.TeamFirstDownPen);

                    }

                    //penalties
                    penaltyNode = doc.SelectSingleNode("/fbgame/team[2]/totals/penalties");
                    if (penaltyNode != null)
                    {
                        reader.ReadToFollowing("penalties");
                        reader.MoveToAttribute("no");
                        //teamPenaltyNo = reader.Value;
                        homeTeamGame.penaltyNo = Convert.ToDecimal(reader.Value);
                        reader.MoveToAttribute("yds");
                        //teamPenaltyYds = reader.Value;
                        homeTeamGame.penaltyYds = Convert.ToDecimal(reader.Value);
                        //output.AppendLine("Penalties: " + homeTeamGame.TeamPenaltyNo + " - " + homeTeamGame.TeamPenaltyYds + " yds");

                    }
                    //conversions
                    conversionsNode = doc.SelectSingleNode("/fbgame/team[2]/totals/conversions");
                    if (penaltyNode != null)
                    {
                        reader.ReadToFollowing("conversions");
                        reader.MoveToAttribute("thirdconv");
                        //teamThirdConv = reader.Value;
                        homeTeamGame.thirdConv = Convert.ToDecimal(reader.Value);
                        reader.MoveToAttribute("thirdatt");
                        //teamThirdAtt = reader.Value;
                        homeTeamGame.thirdAtt = Convert.ToDecimal(reader.Value);
                        reader.MoveToAttribute("fourthconv");
                        //teamFourthConv = reader.Value;
                        homeTeamGame.fourthConv = Convert.ToDecimal(reader.Value);
                        reader.MoveToAttribute("fourthatt");
                        //teamFourthAtt = reader.Value;
                        homeTeamGame.fourthAtt = Convert.ToDecimal(reader.Value);
                        //output.AppendLine("Conversions: ");
                        //output.AppendLine("  ---3rd down: " + homeTeamGame.TeamThirdConv + "-" + homeTeamGame.TeamThirdAtt);
                        //output.AppendLine("  ---4th down: " + homeTeamGame.TeamFourthConv + "-" + homeTeamGame.TeamFourthAtt);
                    }




                    //fumbles
                    fumblesNode = doc.SelectSingleNode("/fbgame/team[2]/totals/fumbles");
                    if (fumblesNode != null)
                    {
                        reader.ReadToFollowing("fumbles");
                        reader.MoveToAttribute("no");
                        homeTeamGame.fumbles = Convert.ToDecimal(reader.Value);
                        reader.MoveToAttribute("lost");
                        homeTeamGame.fumblesLost = Convert.ToDecimal(reader.Value);
                        //output.AppendLine("Fumbles: " + teamFumbles);
                        //output.AppendLine("  ---Lost: " + teamFumblesLost);
                    }
                    //misc
                    miscNode = doc.SelectSingleNode("/fbgame/team[2]/totals/misc");
                    if(miscNode != null)
                    {
                        reader.ReadToFollowing("misc");
                        reader.MoveToAttribute("yds");
                        homeTeamGame.miscYds = Convert.ToDecimal(reader.Value);
                        reader.MoveToAttribute("top");
                        homeTeamGame.timeOfPoss = reader.Value;
                        reader.MoveToAttribute("ona");
                        homeTeamGame.onsideAtt = Convert.ToDecimal(reader.Value);
                        reader.MoveToAttribute("onm");
                        homeTeamGame.onsideMade = Convert.ToDecimal(reader.Value);
                        reader.MoveToAttribute("ptsto");
                        homeTeamGame.pointsOffTurnovers = Convert.ToDecimal(reader.Value);
                        //output.AppendLine("Misc. Yds: " + teamMiscYds);
                        //output.AppendLine("T.O.P.: " + teamTimeOfPoss);
                        //output.AppendLine("Onside Kicks (made-att): " + teamOnsideMade + "-" + teamOnsideAtt);
                        //output.AppendLine("Pts Off Turnovers: " + teamPointsOffTurnovers);
                    }



                    //redzone
                    redzoneNode = doc.SelectSingleNode("/fbgame/team[2]/totals/redzone");
                    if (redzoneNode != null)
                    {
                        reader.ReadToFollowing("redzone");
                        reader.MoveToAttribute("att");
                        homeTeamGame.rzAtt = Convert.ToDecimal(reader.Value);
                        reader.MoveToAttribute("scores");
                        homeTeamGame.rzScores = Convert.ToDecimal(reader.Value);
                        reader.MoveToAttribute("points");
                        homeTeamGame.rzPoints = Convert.ToDecimal(reader.Value);
                        reader.MoveToAttribute("tdrush");
                        homeTeamGame.rzTdRush = Convert.ToDecimal(reader.Value);
                        reader.MoveToAttribute("tdpass");
                        homeTeamGame.rzTdPass = Convert.ToDecimal(reader.Value);
                        reader.MoveToAttribute("fgmade");
                        homeTeamGame.rzFgMade = Convert.ToDecimal(reader.Value);
                        reader.MoveToAttribute("endfga");
                        homeTeamGame.rzEndFga = Convert.ToDecimal(reader.Value);
                        reader.MoveToAttribute("enddowns");
                        homeTeamGame.rzEndDowns = Convert.ToDecimal(reader.Value);
                        reader.MoveToAttribute("endint");
                        homeTeamGame.rzEndInt = Convert.ToDecimal(reader.Value);
                        reader.MoveToAttribute("endfumb");
                        homeTeamGame.rzEndFumb = Convert.ToDecimal(reader.Value);
                        reader.MoveToAttribute("endhalf");
                        homeTeamGame.rzEndHalf = Convert.ToDecimal(reader.Value);
                        reader.MoveToAttribute("endgame");
                        homeTeamGame.rzEndGame = Convert.ToDecimal(reader.Value);
                        //output.AppendLine("Redzone: ");
                        //output.AppendLine("  ---Attempts: " + teamRzAtt);
                        //output.AppendLine("  ---Scores: " + teamRzScores);
                        //output.AppendLine("  ---Points: " + teamRzPoints);
                        //output.AppendLine("  ---Rush TD: " + teamRzTdRush);
                        //output.AppendLine("  ---Pass TD: " + teamRzTdPass);
                        //output.AppendLine("  ---FG Made: " + teamRzFgMade);
                        //output.AppendLine("  ---End FGA: " + teamRzEndFga);
                        //output.AppendLine("  ---End Downs: " + teamRzEndDowns);
                        //output.AppendLine("  ---End Int: " + teamRzEndInt);
                        //output.AppendLine("  ---End Fumb: " + teamRzEndFumb);
                        //output.AppendLine("  ---End Half: " + teamRzEndHalf);
                        //output.AppendLine("  ---End Game: " + teamRzEndGame);
                    }
                    //rushing
                    rushNode = doc.SelectSingleNode("/fbgame/team[2]/totals/rush");
                    if (rushNode != null)
                    {
                        reader.ReadToFollowing("rush");
                        reader.MoveToAttribute("att");
                        homeTeamGame.rushAtt = Convert.ToDecimal(reader.Value);
                        reader.MoveToAttribute("yds");
                        homeTeamGame.rushYds = Convert.ToDecimal(reader.Value);
                        reader.MoveToAttribute("gain");
                        homeTeamGame.rushGain = Convert.ToDecimal(reader.Value);
                        reader.MoveToAttribute("loss");
                        homeTeamGame.rushLoss = Convert.ToDecimal(reader.Value);
                        reader.MoveToAttribute("td");
                        homeTeamGame.rushTd = Convert.ToDecimal(reader.Value);
                        reader.MoveToAttribute("long");
                        homeTeamGame.rushLong = Convert.ToDecimal(reader.Value);
                        //output.AppendLine("Rushing: ");
                        //output.AppendLine("  ---Attempts: " + teamRushAtt);
                        //output.AppendLine("  ---Yds: " + teamRushYds);
                        //output.AppendLine("  ---Gain: " + teamRushGain);
                        //output.AppendLine("  ---Loss: " + teamRushLoss);
                        //output.AppendLine("  ---TD: " + teamRushTd);
                        //output.AppendLine("  ---Long: " + teamRushLong);
                    }


                    //passing
                    passNode = doc.SelectSingleNode("/fbgame/team[2]/totals/pass");
                    if (passNode != null)
                    {

                        reader.ReadToFollowing("pass");
                        reader.MoveToAttribute("comp");
                        homeTeamGame.passComp = Convert.ToDecimal(reader.Value);
                        reader.MoveToAttribute("att");
                        homeTeamGame.passAtt = Convert.ToDecimal(reader.Value);
                        reader.MoveToAttribute("int");
                        homeTeamGame.passInt = Convert.ToDecimal(reader.Value);
                        reader.MoveToAttribute("yds");
                        homeTeamGame.passYds = Convert.ToDecimal(reader.Value);
                        reader.MoveToAttribute("td");
                        homeTeamGame.passTd = Convert.ToDecimal(reader.Value);
                        reader.MoveToAttribute("long");
                        homeTeamGame.passLong = Convert.ToDecimal(reader.Value);
                        reader.MoveToAttribute("sacks");
                        homeTeamGame.passSacks = Convert.ToDecimal(reader.Value);
                        reader.MoveToAttribute("sackyds");
                        homeTeamGame.passSackYds = Convert.ToDecimal(reader.Value);
                        //output.AppendLine("Passing: ");
                        //output.AppendLine("  ---Completions: " + teamPassComp);
                        //output.AppendLine("  ---Attempts: " + teamPassAtt);
                        //output.AppendLine("  ---Interceptions: " + teamPassInt);
                        //output.AppendLine("  ---Yds: " + teamPassYds);
                        //output.AppendLine("  ---TD: " + teamPassTd);
                        //output.AppendLine("  ---Long: " + teamPassLong);
                        //output.AppendLine("  ---Sacks: " + teamPassSacks);
                        //output.AppendLine("  ---Sack Yds: " + teamPassSackYds);
                    }
                    //receiving
                    rcvNode = doc.SelectSingleNode("/fbgame/team[2]/totals/rcv");
                    if (rcvNode != null)
                    {
                        reader.ReadToFollowing("rcv");
                        reader.MoveToAttribute("no");
                        homeTeamGame.rcvNo = Convert.ToDecimal(reader.Value);
                        reader.MoveToAttribute("yds");
                        homeTeamGame.rcvYds = Convert.ToDecimal(reader.Value);
                        reader.MoveToAttribute("td");
                        homeTeamGame.rcvTd = Convert.ToDecimal(reader.Value);
                        reader.MoveToAttribute("long");
                        homeTeamGame.rcvLong = Convert.ToDecimal(reader.Value);
                        //output.AppendLine("Receiving: ");
                        //output.AppendLine("  ---Number: " + teamRcvNo);
                        //output.AppendLine("  ---Yds: " + teamRcvYds);
                        //output.AppendLine("  ---TDs: " + teamRcvTd);
                        //output.AppendLine("  ---Long: " + teamRcvLong);
                    }
                    //punting
                    puntNode = doc.SelectSingleNode("/fbgame/team[2]/totals/punt");
                    if (puntNode != null)
                    {
                        reader.ReadToFollowing("punt");
                        reader.MoveToAttribute("no");
                        homeTeamGame.puntNo = Convert.ToDecimal(reader.Value);
                        reader.MoveToAttribute("yds");
                        homeTeamGame.puntYds = Convert.ToDecimal(reader.Value);
                        reader.MoveToAttribute("long");
                        homeTeamGame.puntLong = Convert.ToDecimal(reader.Value);
                        reader.MoveToAttribute("blkd");
                        homeTeamGame.puntBlkd = Convert.ToDecimal(reader.Value);
                        reader.MoveToAttribute("tb");
                        homeTeamGame.puntTb = Convert.ToDecimal(reader.Value);
                        reader.MoveToAttribute("fc");
                        homeTeamGame.puntFc = Convert.ToDecimal(reader.Value);
                        reader.MoveToAttribute("plus50");
                        homeTeamGame.puntPlus50 = Convert.ToDecimal(reader.Value);
                        reader.MoveToAttribute("inside20");
                        homeTeamGame.puntInside20 = Convert.ToDecimal(reader.Value);

                        //output.AppendLine("Punting: ");
                        //output.AppendLine("  ---Number: " + teamPuntNo);
                        //output.AppendLine("  ---Yds: " + teamPuntYds);
                        //output.AppendLine("  ---Long: " + teamPuntLong);
                        //output.AppendLine("  ---Punts Blocked: " + teamPuntBlkd);
                        //output.AppendLine("  ---Punts TB?: " + teamPuntTb);
                        //output.AppendLine("  ---Punts Fc: " + teamPuntFc);
                        //output.AppendLine("  ---Punts plus50: " + teamPuntPlus50);
                        //output.AppendLine("  ---Punts inside the 20: " + teamPuntInside20);
                    }
                    //ko
                    koNode = doc.SelectSingleNode("/fbgame/team[2]/totals/ko");
                    if (koNode != null)
                    {


                        reader.ReadToFollowing("ko");
                        reader.MoveToAttribute("no");
                        homeTeamGame.koNo = Convert.ToDecimal(reader.Value);
                        reader.MoveToAttribute("yds");
                        homeTeamGame.koYds = Convert.ToDecimal(reader.Value);
                        reader.MoveToAttribute("ob");
                        homeTeamGame.koOb = Convert.ToDecimal(reader.Value);
                        reader.MoveToAttribute("tb");
                        homeTeamGame.koTb = Convert.ToDecimal(reader.Value);
                        //output.AppendLine("Kickoffs: ");
                        //output.AppendLine("  ---Kickoff Attempts: " + teamKoAtt);
                        //output.AppendLine("  ---Kickoff Yards: " + teamKoYds);
                        //output.AppendLine("  ---Kickoffs OB: " + teamKoOb);
                        //output.AppendLine("  ---Touchbacks: " + teamKoTb);
                    }

                    //fg
                    fgNode = doc.SelectSingleNode("/fbgame/team[2]/totals/fg");

                    if (fgNode != null)
                    {
                        reader.ReadToFollowing("fg");
                        reader.MoveToAttribute("att");
                        homeTeamGame.fgAtt = Convert.ToDecimal(reader.Value);
                        reader.MoveToAttribute("long");
                        homeTeamGame.fgLong = Convert.ToDecimal(reader.Value);
                        reader.MoveToAttribute("blkd");
                        homeTeamGame.fgBlkd = Convert.ToDecimal(reader.Value);
                        reader.MoveToAttribute("made");
                        homeTeamGame.fgMade = Convert.ToDecimal(reader.Value);
                        //output.AppendLine("Field Goals: ");
                        //output.AppendLine("  ---Field Goal Attempts: " + teamFgAtt);
                        //output.AppendLine("  ---Field Goal Long: " + teamFgLong);
                        //output.AppendLine("  ---Field Goals Blocked: " + teamFgBlkd);
                        //output.AppendLine("  ---Field Goals Made: " + teamFgMade);
                    }

                    //pat
                    patNode = doc.SelectSingleNode("/fbgame/team[2]/totals/pat");

                    if (patNode != null)
                    {
                        reader.ReadToFollowing("pat");

                        reader.MoveToFirstAttribute();

                        for (int y = 0; y < patNode.Attributes.Count; y++)
                        {
                            if (reader.Name == "kickatt")
                            {
                                homeTeamGame.patKickAtt = Convert.ToDecimal(reader.Value);
                            }

                            if (reader.Name == "kickmade")
                            {
                                homeTeamGame.patKickMade = Convert.ToDecimal(reader.Value);
                            }

                            if (reader.Name == "passatt")
                            {
                                homeTeamGame.patPassAtt = Convert.ToDecimal(reader.Value);
                            }

                            if (reader.Name == "passmade")
                            {
                                homeTeamGame.patPassMade = Convert.ToDecimal(reader.Value);
                            }

                            if (reader.Name == "rushatt")
                            {
                                homeTeamGame.patRushAtt = Convert.ToDecimal(reader.Value);
                            }

                            if (reader.Name == "rushmade")
                            {
                                homeTeamGame.patRushMade = Convert.ToDecimal(reader.Value);
                            }

                            reader.MoveToNextAttribute();
                        }
                    }

                    //defense
                    defenseNode = doc.SelectSingleNode("/fbgame/team[2]/totals/defense");

                    if (defenseNode != null)
                    {
                        reader.ReadToFollowing("defense");

                        //output.AppendLine("Defense:");

                        reader.MoveToFirstAttribute();

                        for (int y = 0; y < defenseNode.Attributes.Count; y++)
                        {

                            if (reader.Name == "tackua")
                            {
                                //defTackUa = reader.Value;
                                homeTeamGame.defTackUA = Convert.ToDecimal(reader.Value);
                                //output.AppendLine("  ---Tackles(UA): " + homeTeamGame.TackUA);
                            }
                            if (reader.Name == "tacka")
                            {
                                //defTackA = reader.Value;
                                homeTeamGame.defTackA = Convert.ToDecimal(reader.Value);
                                //output.AppendLine("  ---Tackles(A): " + homeTeamGame.TackA);
                            }
                            if (reader.Name == "tflua")
                            {
                                //defTflUa = reader.Value;
                                homeTeamGame.defTflUA = Convert.ToDecimal(reader.Value);
                                //output.AppendLine("  ---TFL(UA): " + homeTeamGame.TflUA);
                            }
                            if (reader.Name == "tfla")
                            {
                                //defTflA = reader.Value;
                                homeTeamGame.defTflA = Convert.ToDecimal(reader.Value);
                                //output.AppendLine("  ---TFL(A): " + homeTeamGame.TflA);
                            }
                            if (reader.Name == "tflyds")
                            {
                                //defTflYds = reader.Value;
                                homeTeamGame.defTflYards = Convert.ToDecimal(reader.Value);
                                //output.AppendLine("  ---TFL Yds: " + homeTeamGame.TflYards);
                            }
                            if (reader.Name == "sacks")
                            {
                                //defSacks = reader.Value;
                                homeTeamGame.defSacks = Convert.ToDecimal(reader.Value);
                                //output.AppendLine("  ---Sacks: " + homeTeamGame.Sacks);
                            }
                            if (reader.Name == "sackyds")
                            {
                                //defSackYds = reader.Value;
                                homeTeamGame.defSackYds = Convert.ToDecimal(reader.Value);
                                //output.AppendLine("  ---Sack Yds: " + homeTeamGame.SackYds);
                            }
                            if (reader.Name == "brup")
                            {
                                //defBrup = reader.Value;
                                homeTeamGame.defBrup = Convert.ToDecimal(reader.Value);
                                //output.AppendLine("  ---Pass Breakups: " + homeTeamGame.Brup);
                            }
                            if (reader.Name == "qbh")
                            {
                                //defQbh = reader.Value;
                                homeTeamGame.defQbh = Convert.ToDecimal(reader.Value);
                                //output.AppendLine("  ---QB Hurries: " + homeTeamGame.Qbh);
                            }
                            if (reader.Name == "blkd")
                            {
                                homeTeamGame.defBlkd = Convert.ToDecimal(reader.Value);
                                //myDefense.Bl = Convert.ToDecimal(reader.Value);
                                //output.AppendLine("  ---Kicks Blkd.: " + defBlkd);
                            }
                            if (reader.Name == "ff")
                            {
                                //defFf = reader.Value;
                                homeTeamGame.defFF = Convert.ToDecimal(reader.Value);
                                //output.AppendLine("  ---Fumbles Forced: " + homeTeamGame.FF);
                            }
                            if (reader.Name == "fr")
                            {
                                //defFr = reader.Value;
                                homeTeamGame.defFR = Convert.ToDecimal(reader.Value);
                                //output.AppendLine("  ---Fumbles Recovered: " + homeTeamGame.FR);
                            }
                            if (reader.Name == "int")
                            {
                                //defInt = reader.Value;
                                homeTeamGame.defInts = Convert.ToDecimal(reader.Value);
                                //output.AppendLine("  ---Interceptions: " + homeTeamGame.Ints);
                            }
                            if (reader.Name == "intyds")
                            {
                                //defIntYds = reader.Value;
                                homeTeamGame.defIntYds = Convert.ToDecimal(reader.Value);
                                //output.AppendLine("  ---Int. Yds: " + homeTeamGame.IntYds);
                            }

                            reader.MoveToNextAttribute();
                        }
                    }

                    //kr
                    krNode = doc.SelectSingleNode("/fbgame/team[2]/totals/kr");

                    if (krNode != null)
                    {
                        reader.ReadToFollowing("kr");
                        reader.MoveToAttribute("td");
                        homeTeamGame.krTd = Convert.ToDecimal(reader.Value);
                        reader.MoveToAttribute("yds");
                        homeTeamGame.krYds = Convert.ToDecimal(reader.Value);
                        reader.MoveToAttribute("no");
                        homeTeamGame.krNo = Convert.ToDecimal(reader.Value);
                        reader.MoveToAttribute("long");
                        homeTeamGame.krLong = Convert.ToDecimal(reader.Value);
                        //output.AppendLine("Kick Returns: ");
                        //output.AppendLine("  ---Kick Return TD: " + teamKrTd);
                        //output.AppendLine("  ---Kick Return Yards: " + teamKrYds);
                        //output.AppendLine("  ---Kick Return Attempts: " + teamKrNo);
                        //output.AppendLine("  ---Kick Return Long: " + teamKrLong);
                    }

                    //pr
                    prNode = doc.SelectSingleNode("/fbgame/team[2]/totals/pr");

                    if (prNode != null)
                    {
                        reader.ReadToFollowing("pr");
                        reader.MoveToAttribute("td");
                        homeTeamGame.prTd = Convert.ToDecimal(reader.Value);
                        reader.MoveToAttribute("yds");
                        homeTeamGame.prYds = Convert.ToDecimal(reader.Value);
                        reader.MoveToAttribute("no");
                        homeTeamGame.prNo = Convert.ToDecimal(reader.Value);
                        reader.MoveToAttribute("long");
                        homeTeamGame.prLong = Convert.ToDecimal(reader.Value);
                        //output.AppendLine("Punt Returns: ");
                        //output.AppendLine("  ---Punt Return TD: " + teamPrTd);
                        //output.AppendLine("  ---Punt Return Yards: " + teamPrYds);
                        //output.AppendLine("  ---Punt Return Attempts: " + teamPrNo);
                        //output.AppendLine("  ---Punt Return Long: " + teamPrLong);
                    }

                    //ir
                    irNode = doc.SelectSingleNode("/fbgame/team[2]/totals/ir");

                    if (irNode != null)
                    {
                        reader.ReadToFollowing("ir");
                        reader.MoveToAttribute("td");
                        homeTeamGame.irTd = Convert.ToDecimal(reader.Value);
                        reader.MoveToAttribute("yds");
                        homeTeamGame.irYds = Convert.ToDecimal(reader.Value);
                        reader.MoveToAttribute("no");
                        homeTeamGame.irNo = Convert.ToDecimal(reader.Value);
                        reader.MoveToAttribute("long");
                        homeTeamGame.irLong = Convert.ToDecimal(reader.Value);
                        //output.AppendLine("Interception Returns: ");
                        //output.AppendLine("  ---Int Return TD: " + teamIrTd);
                        //output.AppendLine("  ---Int Return Yards: " + teamIrYds);
                        //output.AppendLine("  ---Int Return Attempts: " + teamIrNo);
                        //output.AppendLine("  ---Int Return Long: " + teamIrLong);
                    }

                    //scoring
                    scoringNode = doc.SelectSingleNode("/fbgame/team[2]/totals/scoring");

                    if (scoringNode != null)
                    {
                        reader.ReadToFollowing("scoring");
                        output.AppendLine("Scoring:");

                        reader.MoveToFirstAttribute();

                        for (int y = 0; y < scoringNode.Attributes.Count; y++)
                        {

                            if (reader.Name == "td")
                            {
                                homeTeamGame.scoringTD = Convert.ToDecimal(reader.Value);
                                //output.AppendLine("  ---TD: " + scoringTd);
                            }
                            if (reader.Name == "fg")
                            {
                                homeTeamGame.scoringFG = Convert.ToDecimal(reader.Value);
                                //output.AppendLine("  ---FG: " + scoringFg);
                            }
                            if (reader.Name == "patkick")
                            {
                                homeTeamGame.scoringPatKick = Convert.ToDecimal(reader.Value);
                                //output.AppendLine("  ---PAT Kick: " + scoringPatKick);
                            }
                            if (reader.Name == "patrush")
                            {
                                homeTeamGame.scoringPatRush = Convert.ToDecimal(reader.Value);
                                //output.AppendLine("  ---PAT Rush: " + scoringPatRush);
                            }
                            if (reader.Name == "patrcv")
                            {
                                homeTeamGame.scoringPatRcv = Convert.ToDecimal(reader.Value);
                                //output.AppendLine("  ---PAT Rcv: " + scoringPatRcv);
                            }
                            if (reader.Name == "saf")
                            {
                                homeTeamGame.scoringSaf = Convert.ToDecimal(reader.Value);
                                //output.AppendLine("  ---Safeties: " + scoringSaf);
                            }

                            reader.MoveToNextAttribute();
                        }
                    }

                    try
                    {
                        findHomeTeam = db.Teams.Single(x => x.name == homeTeamGame.teamName);
                    }
                    catch (Exception e)
                    {
                        
                    }

                    if (findHomeTeam.name == null)
                    {
                        Team newTeam = new Team();
                        newTeam.name = homeTeamGame.teamName;
                        db.Teams.Add(newTeam);
                        db.SaveChanges();
                        homeTeamGame.team_Id = newTeam.team_Id;
                    }

                    if (findHomeTeam.name != null)
                    {
                        homeTeamGame.team_Id = findHomeTeam.team_Id;
                    }

                    homeTeamGame.game_Id = game.game_Id;

                    db.TeamGames.Add(homeTeamGame);
                    db.SaveChanges();

                    homeLinescore.teamGame_Id = homeTeamGame.teamGame_Id;

                    db.Linescores.Add(homeLinescore);
                    db.SaveChanges();

                    foreach (var l in homeLineprds)
                    {
                        l.linescore_Id = homeLinescore.linescore_Id;

                        db.Lineprds.Add(l);
                    }
                    db.SaveChanges();

                    #region players
                    //player
                    if (homeTeamGame.teamName == "Alabama" || homeTeamGame.teamName == "Alabama Crimson Tide" || homeTeamGame.teamName == "ALABAMA" || homeTeamGame.teamName == "UA")
                    {
                        //output.AppendLine("Players: ");

                        int playerCount = teamNode.ChildNodes.Count - 1;
                        int i = 1;
                        do
                        {
                            playerGame = new PlayerGame();

                            playerNode = doc.SelectSingleNode("/fbgame/team[2]/player[" + i + "]");
                            reader.ReadToFollowing("player");

                            reader.MoveToAttribute("name");
                            playerName = reader.Value;
                            reader.MoveToAttribute("uni");
                            playerGame.uni = reader.Value;
                            reader.MoveToAttribute("class");
                            playerGame.@class = reader.Value;


                            for (int y = 0; y < playerNode.Attributes.Count; y++)
                            {
                                if (playerNode.Attributes[y].Name == "gp")
                                {
                                    reader.MoveToAttribute("gp");
                                    playerGame.gp = reader.Value;
                                }

                                if (playerNode.Attributes[y].Name == "gs")
                                {
                                    reader.MoveToAttribute("gs");
                                    playerGame.gs = reader.Value;
                                }

                                if (playerNode.Attributes[y].Name == "opos")
                                {
                                    reader.MoveToAttribute("opos");
                                    playerGame.oPos = reader.Value;
                                }

                                if (playerNode.Attributes[y].Name == "dpos")
                                {
                                    reader.MoveToAttribute("dpos");
                                    playerGame.dPos = reader.Value;
                                }
                            }

                            playerGame.playerGame_Id = playerName + playerGame.uni + playerGame.@class + game.date_;

                            //output.AppendLine("  " + playerId + " " + playerName + " #" + playerUni + " " + playerPos + ", " + playerClass);

                            if (playerNode.HasChildNodes)
                            {
                                for (int x = 0; x < playerNode.ChildNodes.Count; x++)
                                {
                                    reader.ReadToFollowing(playerNode.ChildNodes[x].Name);

                                    //rushing
                                    if (reader.Name == "rush")
                                    {
                                        rush = new Rush();

                                        //output.AppendLine("    Rush");
                                        reader.MoveToAttribute("att");
                                        rush.att = Convert.ToDecimal(reader.Value);
                                        //output.AppendLine("      Att: " + rushAtt);
                                        reader.MoveToAttribute("yds");
                                        rush.yds = Convert.ToDecimal(reader.Value);
                                        //output.AppendLine("      Yds: " + rushYds);
                                        reader.MoveToAttribute("gain");
                                        rush.gain = Convert.ToDecimal(reader.Value);
                                        //output.AppendLine("      Gain: " + rushGain);
                                        reader.MoveToAttribute("loss");
                                        rush.loss = Convert.ToDecimal(reader.Value);
                                        //output.AppendLine("      Loss: " + rushLoss);
                                        reader.MoveToAttribute("td");
                                        rush.td = Convert.ToDecimal(reader.Value);
                                        //output.AppendLine("      TD: " + rushTd);
                                        reader.MoveToAttribute("long");
                                        rush.@long = Convert.ToDecimal(reader.Value);
                                        //output.AppendLine("      Long: " + rushLong);
                                        rush.playerGame_Id = playerGame.playerGame_Id;
                                    }

                                    //passing
                                    if (reader.Name == "pass")
                                    {
                                        pass = new Pass();

                                        //output.AppendLine("    Pass");
                                        reader.MoveToAttribute("comp");
                                        pass.comp = Convert.ToDecimal(reader.Value);
                                        //output.AppendLine("      Comp: " + passComp);
                                        reader.MoveToAttribute("att");
                                        pass.att = Convert.ToDecimal(reader.Value);
                                        //output.AppendLine("      Att: " + passAtt);
                                        reader.MoveToAttribute("int");
                                        pass.int_ = Convert.ToDecimal(reader.Value);
                                        //output.AppendLine("      Int: " + passInt);
                                        reader.MoveToAttribute("yds");
                                        pass.yds = Convert.ToDecimal(reader.Value);
                                        //output.AppendLine("      Yds: " + passYds);
                                        reader.MoveToAttribute("td");
                                        pass.td = Convert.ToDecimal(reader.Value);
                                        //output.AppendLine("      TD: " + passTd);
                                        reader.MoveToAttribute("long");
                                        pass.@long = Convert.ToDecimal(reader.Value);
                                        //output.AppendLine("      Long: " + passLong);
                                        reader.MoveToAttribute("sacks");
                                        pass.sacks = Convert.ToDecimal(reader.Value);
                                        //output.AppendLine("      Sacks: " + passSacks);
                                        reader.MoveToAttribute("sackyds");
                                        pass.sackYds = Convert.ToDecimal(reader.Value);
                                        //output.AppendLine("      SackYds: " + passSackYds);
                                        pass.playerGame_Id = playerGame.playerGame_Id;
                                    }

                                    //receiving
                                    if (reader.Name == "rcv")
                                    {
                                        rcv = new Rcv();

                                        //output.AppendLine("    Receiving");
                                        reader.MoveToAttribute("no");
                                        rcv.no_ = Convert.ToDecimal(reader.Value);
                                        //output.AppendLine("      No: " + rcvNo);
                                        reader.MoveToAttribute("yds");
                                        rcv.yds = Convert.ToDecimal(reader.Value);
                                        //output.AppendLine("      Yards: " + rcvYds);
                                        reader.MoveToAttribute("td");
                                        rcv.td = Convert.ToDecimal(reader.Value);
                                        //output.AppendLine("      TD: " + rcvTd);
                                        reader.MoveToAttribute("long");
                                        rcv.@long = Convert.ToDecimal(reader.Value);
                                        //output.AppendLine("      Long: " + rcvLong);
                                        rcv.playerGame_Id = playerGame.playerGame_Id;
                                    }

                                    //punting
                                    if (reader.Name == "punt")
                                    {
                                        punt = new Punt();

                                        //output.AppendLine("    Punt");
                                        reader.MoveToAttribute("yds");
                                        punt.yds_ = Convert.ToDecimal(reader.Value);
                                        //output.AppendLine("      Yds: " + puntYds);
                                        reader.MoveToAttribute("no");
                                        punt.no_ = Convert.ToDecimal(reader.Value);
                                        //output.AppendLine("      Att: " + puntNo);
                                        reader.MoveToAttribute("long");
                                        punt.long_ = Convert.ToDecimal(reader.Value);
                                        //output.AppendLine("      Long: " + puntLong);
                                        reader.MoveToAttribute("inside20");
                                        punt.inside20 = Convert.ToDecimal(reader.Value);
                                        //output.AppendLine("      Inside 20: " + puntInside20);
                                        reader.MoveToAttribute("plus50");
                                        punt.plus50 = Convert.ToDecimal(reader.Value);
                                        //output.AppendLine("      Plus 50: " + puntPlus50);
                                        reader.MoveToAttribute("fc");
                                        punt.fc = Convert.ToDecimal(reader.Value);
                                        //output.AppendLine("      Fair Catch: " + puntFc);
                                        reader.MoveToAttribute("tb");
                                        punt.tb = Convert.ToDecimal(reader.Value);
                                        //output.AppendLine("      Touchbacks: " + puntTb);
                                        reader.MoveToAttribute("blkd");
                                        punt.blkd_ = Convert.ToDecimal(reader.Value);
                                        //output.AppendLine("      Blocked: " + puntBlkd);
                                        punt.playerGame_Id = playerGame.playerGame_Id;
                                    }

                                    //kickoff
                                    if (reader.Name == "ko")
                                    {
                                        ko = new Ko();

                                        //output.AppendLine("    KO");
                                        reader.MoveToAttribute("no");
                                        ko.no_ = Convert.ToDecimal(reader.Value);
                                        //output.AppendLine("      KO Att: " + koAtt);
                                        reader.MoveToAttribute("yds");
                                        ko.yds = Convert.ToDecimal(reader.Value);
                                        //output.AppendLine("      KO Yds: " + koYds);
                                        reader.MoveToAttribute("ob");
                                        ko.ob = Convert.ToDecimal(reader.Value);
                                        //output.AppendLine("      # Out of bounds: " + koOb);
                                        reader.MoveToAttribute("tb");
                                        ko.tb = Convert.ToDecimal(reader.Value);
                                        //output.AppendLine("      Touchbacks: " + touchbacks);
                                        ko.playerGame_Id = playerGame.playerGame_Id;
                                    }

                                    //field goals
                                    if (reader.Name == "fg")
                                    {
                                        fg = new Fg();

                                        //output.AppendLine("    FG");
                                        reader.MoveToAttribute("att");
                                        fg.att = Convert.ToDecimal(reader.Value);
                                        //output.AppendLine("      FG Att: " + fgAtt);
                                        reader.MoveToAttribute("long");
                                        fg.@long = Convert.ToDecimal(reader.Value);
                                        //output.AppendLine("      FG Long: " + fgLong);
                                        reader.MoveToAttribute("blkd");
                                        fg.blkd = Convert.ToDecimal(reader.Value);
                                        //output.AppendLine("      FG Blocked: " + fgBlkd);
                                        reader.MoveToAttribute("made");
                                        fg.made = Convert.ToDecimal(reader.Value);
                                        //output.AppendLine("      FG Made: " + fgMade);
                                        fg.playerGame_Id = playerGame.playerGame_Id;
                                    }

                                    //PAT
                                    if (reader.Name == "pat")
                                    {
                                        patNode = doc.SelectSingleNode("/fbgame/team[2]/player[" + i + "]/pat");

                                        pat = new Pat();

                                        reader.MoveToFirstAttribute();

                                        for (int y = 0; y < patNode.Attributes.Count; y++)
                                        {
                                            if (reader.Name == "kickatt")
                                            {
                                                pat.kickAtt = Convert.ToDecimal(reader.Value);
                                            }

                                            if (reader.Name == "kickmade")
                                            {
                                                pat.kickMade = Convert.ToDecimal(reader.Value);
                                            }

                                            if (reader.Name == "passatt")
                                            {
                                                pat.passAtt = Convert.ToDecimal(reader.Value);
                                            }

                                            if (reader.Name == "passmade")
                                            {
                                                pat.passMade = Convert.ToDecimal(reader.Value);
                                            }

                                            if (reader.Name == "rushatt")
                                            {
                                                pat.rushAtt = Convert.ToDecimal(reader.Value);
                                            }

                                            if (reader.Name == "rushmade")
                                            {
                                                pat.rushMade = Convert.ToDecimal(reader.Value);
                                            }

                                            reader.MoveToNextAttribute();
                                        }
                                        pat.playerGame_Id = playerGame.playerGame_Id;
                                    }

                                    //defense
                                    if (reader.Name == "defense")
                                    {
                                        defenseNode = doc.SelectSingleNode("/fbgame/team[2]/player[" + i + "]/defense");
                                        //output.AppendLine("    Defense");

                                        defense = new Defense();

                                        reader.MoveToFirstAttribute();

                                        for (int y = 0; y < defenseNode.Attributes.Count; y++)
                                        {

                                            if (reader.Name == "tackua")
                                            {
                                                defense.tackUA = Convert.ToDecimal(reader.Value);
                                                //output.AppendLine("      Tackles(UA): " + defTackUa);
                                            }
                                            if (reader.Name == "tacka")
                                            {
                                                defense.tackA = Convert.ToDecimal(reader.Value);
                                                //output.AppendLine("      Tackles(A): " + defTackA);
                                            }
                                            if (reader.Name == "tflua")
                                            {
                                                defense.tflUA = Convert.ToDecimal(reader.Value);
                                                //output.AppendLine("      TFL(UA): " + defTflUa);
                                            }
                                            if (reader.Name == "tfla")
                                            {
                                                defense.tflA = Convert.ToDecimal(reader.Value);
                                                //output.AppendLine("      TFL(A): " + defTflA);
                                            }
                                            if (reader.Name == "tflyds")
                                            {
                                                defense.tflYds = Convert.ToDecimal(reader.Value);
                                                //output.AppendLine("      TFL Yds: " + defTflYds);
                                            }
                                            if (reader.Name == "sacks")
                                            {
                                                defense.sacks = Convert.ToDecimal(reader.Value);
                                                //output.AppendLine("      Sacks: " + defSacks);
                                            }
                                            if (reader.Name == "sackyds")
                                            {
                                                defense.sackYds = Convert.ToDecimal(reader.Value);
                                                //output.AppendLine("      Sack Yds: " + defSackYds);
                                            }
                                            if (reader.Name == "brup")
                                            {
                                                defense.brup = Convert.ToDecimal(reader.Value);
                                                //output.AppendLine("      Pass Breakups: " + defBrup);
                                            }
                                            if (reader.Name == "qbh")
                                            {
                                                defense.qbh = Convert.ToDecimal(reader.Value);
                                                //output.AppendLine("      QB Hurries: " + defQbh);
                                            }
                                            if (reader.Name == "blkd")
                                            {
                                                defense.blkd = Convert.ToDecimal(reader.Value);
                                                //output.AppendLine("      Kicks Blkd.: " + defBlkd);
                                            }
                                            if (reader.Name == "ff")
                                            {
                                                defense.ff = Convert.ToDecimal(reader.Value);
                                                //output.AppendLine("      Fumbles Forced: " + defFf);
                                            }
                                            if (reader.Name == "fr")
                                            {
                                                defense.fr = Convert.ToDecimal(reader.Value);
                                                //output.AppendLine("      Fumbles Recovered: " + defFr);
                                            }
                                            if (reader.Name == "fryds")
                                            {
                                                defense.frYds = Convert.ToDecimal(reader.Value);
                                                //output.AppendLine("      Fumb. Rec. Yds: " + defFrYds);
                                            }
                                            if (reader.Name == "int")
                                            {
                                                defense.ints = Convert.ToDecimal(reader.Value);
                                                //output.AppendLine("      Interceptions: " + defInt);
                                            }
                                            if (reader.Name == "intyds")
                                            {
                                                defense.intYds = Convert.ToDecimal(reader.Value);
                                                //output.AppendLine("      Int. Yds: " + defIntYds);
                                            }

                                            reader.MoveToNextAttribute();
                                        }

                                        defense.playerGame_Id = playerGame.playerGame_Id;
                                    }

                                    //fumbles
                                    if (reader.Name == "fumbles")
                                    {
                                        fumble = new Fumble();

                                        //output.AppendLine("    Fumbles");
                                        reader.MoveToAttribute("no");
                                        fumble.no_ = reader.Value;
                                        //output.AppendLine("      Fumbles: " + fumbles);
                                        reader.MoveToAttribute("lost");
                                        fumble.lost = reader.Value;
                                        //output.AppendLine("      Lost: " + fumblesLost);
                                        fumble.playerGame_Id = playerGame.playerGame_Id;
                                    }

                                    //kick returns
                                    if (reader.Name == "kr")
                                    {
                                        kr = new Kr();

                                        //output.AppendLine("    Kick Returns");
                                        reader.MoveToAttribute("td");
                                        kr.td = Convert.ToDecimal(reader.Value);
                                        //output.AppendLine("     Touchdowns: " + krTd);
                                        reader.MoveToAttribute("yds");
                                        kr.yds_ = Convert.ToDecimal(reader.Value);
                                        //output.AppendLine("     Yards: " + krYds);
                                        reader.MoveToAttribute("no");
                                        kr.no_ = Convert.ToDecimal(reader.Value);
                                        //output.AppendLine("     Attempts: " + krNo);
                                        reader.MoveToAttribute("long");
                                        kr.@long = Convert.ToDecimal(reader.Value);
                                        //output.AppendLine("     Long: " + krLong);
                                        kr.playerGame_Id = playerGame.playerGame_Id;
                                    }

                                    //punt returns
                                    if (reader.Name == "pr")
                                    {
                                        pr = new Pr();

                                        //output.AppendLine("    Punt Returns");
                                        reader.MoveToAttribute("td");
                                        pr.td = Convert.ToDecimal(reader.Value);
                                        //output.AppendLine("     Touchdowns: " + prTd);
                                        reader.MoveToAttribute("yds");
                                        pr.yds = Convert.ToDecimal(reader.Value);
                                        //output.AppendLine("     Yards: " + prYds);
                                        reader.MoveToAttribute("no");
                                        pr.no_ = Convert.ToDecimal(reader.Value);
                                        //output.AppendLine("     Attempts: " + prNo);
                                        reader.MoveToAttribute("long");
                                        pr.@long = Convert.ToDecimal(reader.Value);
                                        //output.AppendLine("     Long: " + prLong);
                                        pr.playerGame_Id = playerGame.playerGame_Id;
                                    }

                                    //interceptions
                                    if (reader.Name == "ir")
                                    {
                                        ir = new Ir();

                                        //output.AppendLine("    Interceptions");
                                        reader.MoveToAttribute("td");
                                        ir.td = Convert.ToDecimal(reader.Value);
                                        //output.AppendLine("     Touchdowns: " + irTd);
                                        reader.MoveToAttribute("yds");
                                        ir.yds = Convert.ToDecimal(reader.Value);
                                        //output.AppendLine("     Yards: " + irYds);
                                        reader.MoveToAttribute("no");
                                        ir.no_ = Convert.ToDecimal(reader.Value);
                                        //output.AppendLine("     Attempts: " + irNo);
                                        reader.MoveToAttribute("long");
                                        ir.@long = Convert.ToDecimal(reader.Value);
                                        //output.AppendLine("     Long: " + irLong);
                                        ir.playerGame_Id = playerGame.playerGame_Id;
                                    }

                                    //scoring
                                    if (reader.Name == "scoring")
                                    {
                                        scoringNode = doc.SelectSingleNode("/fbgame/team[2]/player[" + i + "]/scoring");
                                        //output.AppendLine("    Scoring");

                                        scoring = new Scoring();

                                        reader.MoveToFirstAttribute();

                                        for (int y = 0; y < scoringNode.Attributes.Count; y++)
                                        {

                                            if (reader.Name == "td")
                                            {
                                                scoring.td = Convert.ToDecimal(reader.Value);
                                                //output.AppendLine("      TD: " + scoringTd);
                                            }
                                            if (reader.Name == "fg")
                                            {
                                                scoring.fg = Convert.ToDecimal(reader.Value);
                                                //output.AppendLine("      FG: " + scoringFg);
                                            }
                                            if (reader.Name == "patkick")
                                            {
                                                scoring.kick = Convert.ToDecimal(reader.Value);
                                                //output.AppendLine("      PAT Kick: " + scoringPatKick);
                                            }
                                            if (reader.Name == "patrush")
                                            {
                                                scoring.rush = Convert.ToDecimal(reader.Value);
                                                //output.AppendLine("      PAT Rush: " + scoringPatRush);
                                            }
                                            if (reader.Name == "patrcv")
                                            {
                                                scoring.rcv = Convert.ToDecimal(reader.Value);
                                                //output.AppendLine("      PAT Rcv: " + scoringPatRcv);
                                            }
                                            if (reader.Name == "saf")
                                            {
                                                scoring.saf = Convert.ToDecimal(reader.Value);
                                                //output.AppendLine("      Safeties: " + scoringSaf);
                                            }

                                            reader.MoveToNextAttribute();
                                        }
                                        scoring.playerGame_Id = playerGame.playerGame_Id;
                                    }

                                }
                            }

                            playerGame.game_Id = game.game_Id;

                            try
                            {
                                findPlayer = db.Players.Single(x => x.name == playerName);
                            }
                            catch (Exception e)
                            {

                            }




                            if (findPlayer.name == null)
                            {
                                player = new Player();

                                player.name = playerName;
                                player.firstGame = Convert.ToDateTime(game.date_);
                                player.lastGame = Convert.ToDateTime(game.date_);
                                player.player_Id = playerName + "-" + game.date_;
                                playerGame.player_Id = player.player_Id;

                                db.Players.Add(player);
                                db.SaveChanges();
                            }

                            if (findPlayer.name != null)
                            {
                                gameDate = Convert.ToDateTime(game.date_);
                                lastGame = Convert.ToDateTime(findPlayer.lastGame);

                                ts = (gameDate - lastGame);

                                yearsSince = ts.Days / 365;

                                if (yearsSince <= 5)
                                {
                                    playerGame.player_Id = findPlayer.player_Id;

                                    if (findPlayer.lastGame < gameDate)
                                    {
                                        findPlayer.lastGame = gameDate;
                                    }

                                    db.SaveChanges();
                                }
                                else
                                {
                                    player = new Player();

                                    player.name = playerName;
                                    player.firstGame = gameDate;
                                    player.lastGame = gameDate;
                                    player.player_Id = playerName + "-" + game.date_;
                                    playerGame.player_Id = player.player_Id;

                                    db.Players.Add(player);
                                    db.SaveChanges();
                                }
                            }

                            db.PlayerGames.Add(playerGame);
                            db.SaveChanges();

                            if (playerGame.playerGame_Id == rush.playerGame_Id)
                            {
                                db.Rushes.Add(rush);
                                db.SaveChanges();
                            }

                            if (playerGame.playerGame_Id == pass.playerGame_Id)
                            {
                                db.Passes.Add(pass);
                                db.SaveChanges();
                            }

                            if (playerGame.playerGame_Id == rcv.playerGame_Id)
                            {
                                db.Rcvs.Add(rcv);
                                db.SaveChanges();
                            }

                            if (playerGame.playerGame_Id == punt.playerGame_Id)
                            {
                                db.Punts.Add(punt);
                                db.SaveChanges();
                            }

                            if (playerGame.playerGame_Id == ko.playerGame_Id)
                            {
                                db.Koes.Add(ko);
                                db.SaveChanges();
                            }

                            if (playerGame.playerGame_Id == fg.playerGame_Id)
                            {
                                db.Fgs.Add(fg);
                                db.SaveChanges();
                            }

                            if (playerGame.playerGame_Id == pat.playerGame_Id)
                            {
                                db.Pats.Add(pat);
                                db.SaveChanges();
                            }

                            if (playerGame.playerGame_Id == kr.playerGame_Id)
                            {
                                db.Krs.Add(kr);
                                db.SaveChanges();
                            }

                            if (playerGame.playerGame_Id == pr.playerGame_Id)
                            {
                                db.Prs.Add(pr);
                                db.SaveChanges();
                            }

                            if (playerGame.playerGame_Id == ir.playerGame_Id)
                            {
                                db.Irs.Add(ir);
                                db.SaveChanges();
                            }

                            if (playerGame.playerGame_Id == scoring.playerGame_Id)
                            {
                                db.Scorings.Add(scoring);
                                db.SaveChanges();
                            }

                            if (playerGame.playerGame_Id == defense.playerGame_Id)
                            {
                                db.Defenses.Add(defense);
                                db.SaveChanges();
                            }

                            if (playerGame.playerGame_Id == fumble.playerGame_Id)
                            {
                                db.Fumbles.Add(fumble);
                                db.SaveChanges();
                            }

                            i++;
                        } while (i < playerCount);
                    }
                #endregion
                #endregion

                //scores
                //output.AppendLine("Scoring Plays: ");
                scoresNode = doc.SelectSingleNode("/fbgame/scores");

                    int scoreCount = scoresNode.ChildNodes.Count;
                    reader.ReadToFollowing("scores");

                    for (int x = 1; x <= scoreCount; x++)
                    {
                        //TODO: check to make sure attributes exist. (i.e. Kenyan Drake KO return had no plays, drive, or t.o.p.)
                        Score scores = new Score();
                        scoresNode = doc.SelectSingleNode("/fbgame/scores/score[" + x + "]");

                        reader.ReadToFollowing("score");
                        reader.MoveToFirstAttribute();
                        for (int y = 0; y < scoresNode.Attributes.Count; y++)
                        {
                            if (reader.Name == "vh")
                            {
                                scores.vh = reader.Value;
                            }
                            if (reader.Name == "team")
                            {
                                scores.team = reader.Value;
                            }
                            if (reader.Name == "qtr")
                            {
                                scores.qtr = reader.Value;
                            }
                            if (reader.Name == "clock")
                            {
                                scores.clock = reader.Value;
                            }
                            if (reader.Name == "type")
                            {
                                scores.type_ = reader.Value;
                            }
                            if (reader.Name == "how")
                            {
                                scores.how = reader.Value;
                            }
                            if (reader.Name == "yds")
                            {
                                scores.yds = Convert.ToDecimal(reader.Value);
                            }
                            if (reader.Name == "scorer")
                            {
                                scores.scorer = reader.Value;
                            }
                            if (reader.Name == "passer")
                            {
                                scores.passer = reader.Value;
                            }
                            if (reader.Name == "patby")
                            {
                                scores.patBy = reader.Value;
                            }
                            if (reader.Name == "pattype")
                            {
                                scores.patType = reader.Value;
                            }
                            if (reader.Name == "patres")
                            {
                                scores.patRes = reader.Value;
                            }
                            if (reader.Name == "plays")
                            {
                                scores.plays = Convert.ToDecimal(reader.Value);
                            }
                            if (reader.Name == "drive")
                            {
                                scores.drive = Convert.ToDecimal(reader.Value);
                            }
                            if (reader.Name == "top")
                            {
                                scores.top_ = reader.Value;
                            }
                            if (reader.Name == "vscore")
                            {
                                scores.vScore = reader.Value;
                            }
                            if (reader.Name == "hscore")
                            {
                                scores.hScore = reader.Value;
                            }
                            if (reader.Name == "driveindex")
                            {
                                scores.driveIndex = reader.Value;
                            }
                            reader.MoveToNextAttribute();
                        }
                        
                        scores.game_Id = game.game_Id;
                        db.Scores.Add(scores);
                        db.SaveChanges();

                        //TODO: Delete the commented out code
                        //if (scoresType == "TD")
                        //{
                        //    if (scoresHow == "PASS")
                        //    {
                        //        output.AppendLine("  -- " + scoresVh + " " + scoresTeam + " - Q" + scoresQtr + " " + scoresClock + " " + scoresYds + "yd " + scoresHow + " " + scoresType + " " + scoresPasser + " to " + scoresScorer + " (PAT " + scoresPatType + " " + scoresPatRes + " by " + scoresPatBy + "), " + scoresVScore + "-" + scoresHScore);
                        //        output.AppendLine("           **Scoring Drive: " + scoresPlays + " plays, " + scoresDrive + " yds, " + scoresTop);
                        //    }
                        //    else
                        //    {
                        //        output.AppendLine("  -- " + scoresVh + " " + scoresTeam + " - Q" + scoresQtr + " " + scoresClock + " " + scoresYds + "yd " + scoresHow + " " + scoresType + " " + scoresScorer + " (PAT " + scoresPatType + " " + scoresPatRes + " by " + scoresPatBy + "), " + scoresVScore + "-" + scoresHScore);
                        //        output.AppendLine("           **Scoring Drive: " + scoresPlays + " plays, " + scoresDrive + " yds, " + scoresTop);
                        //    }
                        //}
                        //else
                        //{
                        //    output.AppendLine("  -- " + scoresVh + " " + scoresTeam + " - Q" + scoresQtr + " " + scoresClock + " " + scoresYds + "yd " + scoresType + " " + scoresScorer + ", " + scoresVScore + "-" + scoresHScore);
                        //    output.AppendLine("           **Scoring Drive: " + scoresPlays + " plays, " + scoresDrive + " yds, " + scoresTop);
                        //}
                    }

                    #region qtr summary
                    //qtrsummary (each quarter and team)


                    //output.AppendLine("Quarter Summary: ");

                    int totalQtrSummaryCount = doc.SelectNodes("fbgame/plays/qtr/qtrsummary").Count;
                    int z = 0;

                    qtrSummaryNode = doc.SelectSingleNode("/fbgame/plays/qtr[1]/qtrsummary[1]");
                    int qtrSummaryCount = qtrSummaryNode.ChildNodes.Count - 1;
                    double qtrCount = 1.0;
                    int checkQtrSummaryCount = 1;

                    while (checkQtrSummaryCount < qtrSummaryCount && z < totalQtrSummaryCount)
                    {
                        QtrSummary myQtrSummary = new QtrSummary();
                        reader.ReadToFollowing("qtrsummary");


                        if (qtrCount == 1.0 || qtrCount == 2.0 || qtrCount == 3.0 || qtrCount == 4.0 || qtrCount == 5.0)
                        {
                            //if (qtrCount == 1.0)
                            //    output.AppendLine("Quarter: 1");
                            //if (qtrCount == 2.0)
                            //    output.AppendLine("Quarter: 2");
                            //if (qtrCount == 3.0)
                            //    output.AppendLine("Quarter: 3");
                            //if (qtrCount == 4.0)
                            //    output.AppendLine("Quarter: 4");

                            //if (qtrCount == 5.0)
                            //    output.AppendLine("Quarter: OT");
                            //output.AppendLine("____________________________");
                            qtrSummaryNode = doc.SelectSingleNode("/fbgame/plays/qtr[" + qtrCount + "]/qtrsummary[1]");
                            scoringNode = doc.SelectSingleNode("/fbgame/plays/qtr[" + qtrCount + "]/qtrsummary[1]/scoring");
                            miscNode = doc.SelectSingleNode("/fbgame/plays/qtr[" + qtrCount + "]/qtrsummary[1]/misc");
                            defenseNode = doc.SelectSingleNode("/fbgame/plays/qtr[" + qtrCount + "]/qtrsummary[1]/defense");

                        }

                        reader.MoveToAttribute("id");
                        myQtrSummary.team = reader.Value;
                        reader.MoveToAttribute("vh");
                        myQtrSummary.vh = reader.Value;
                    //output.AppendLine("Team: " + TeamID);
                    //output.AppendLine("---------");
                        if (qtrCount == 1.5 || qtrCount == 2.5 || qtrCount == 3.5 || qtrCount == 4.5 || qtrCount == 5.5)
                        {

                            qtrSummaryNode = doc.SelectSingleNode("/fbgame/plays/qtr[" + (qtrCount - 0.5) + "]/qtrsummary[2]");
                            scoringNode = doc.SelectSingleNode("/fbgame/plays/qtr[" + (qtrCount - 0.5) + "]/qtrsummary[2]/scoring");
                            miscNode = doc.SelectSingleNode("/fbgame/plays/qtr[" + (qtrCount - 0.5) + "]/qtrsummary[2]/misc");
                            defenseNode = doc.SelectSingleNode("/fbgame/plays/qtr[" + (qtrCount - 0.5) + "]/qtrsummary[2]/defense");
                        }
                        if (qtrSummaryNode.HasChildNodes)
                        {
                            for (int x = 0; x < qtrSummaryNode.ChildNodes.Count; x++)
                            {
                                reader.ReadToFollowing(qtrSummaryNode.ChildNodes[x].Name);

                                //rushing
                                if (reader.Name == "firstdowns")
                                {
                                    //first downs
                                    //TODO: Move this to the FirstDown in the totals section at the beginning of the document
                                    reader.MoveToAttribute("no");
                                    //qtrSummaryFirstDownNo = reader.Value;
                                    myQtrSummary.firstDownNo = Convert.ToDecimal(reader.Value);
                                    //output.AppendLine("First Downs: " + myQtrSummary.TeamFirstDownNo);
                                    reader.MoveToAttribute("rush");
                                    //qtrSummaryFirstDownRush = reader.Value;
                                    myQtrSummary.firstDownRush = Convert.ToDecimal(reader.Value);
                                    //output.AppendLine("   ----Rush: " + myQtrSummary.TeamFirstDownRush);
                                    reader.MoveToAttribute("pass");
                                    //qtrSummaryFirstDownPass = reader.Value;
                                    myQtrSummary.firstDownPass = Convert.ToDecimal(reader.Value);
                                    //output.AppendLine("   ----Pass: " + myQtrSummary.TeamFirstDownPass);
                                    reader.MoveToAttribute("penalty");
                                    // qtrSummaryFirstDownPenalty = reader.Value;
                                    myQtrSummary.firstDownPen = Convert.ToDecimal(reader.Value);
                                    //output.AppendLine("   ----Penalty: " + myQtrSummary.TeamFirstDownPen);
                                }
                                if (reader.Name == "penalties")
                                {

                                    reader.MoveToAttribute("no");
                                    //qtrSummaryPenaltiesNo = reader.Value;
                                    myQtrSummary.penaltyNo = Convert.ToDecimal(reader.Value);
                                    reader.MoveToAttribute("yds");
                                    //qtrSummaryPenaltiesYds = reader.Value;
                                    myQtrSummary.penaltyYds = Convert.ToDecimal(reader.Value);
                                    //output.AppendLine("Penalties: " + myQtrSummary.TeamPenaltyNo + " - " + myQtrSummary.TeamPenaltyYds + " yds");
                                }
                                if (reader.Name == "conversions")
                                {

                                    reader.MoveToAttribute("thirdconv");
                                    //qtrSummaryConversionsThirdConv = reader.Value;
                                    myQtrSummary.thirdConv = Convert.ToDecimal(reader.Value);
                                    reader.MoveToAttribute("thirdatt");
                                    //qtrSummaryConversionsThirdAtt = reader.Value;
                                    myQtrSummary.thirdAtt = Convert.ToDecimal(reader.Value);
                                    reader.MoveToAttribute("fourthconv");
                                    //qtrSummaryConversionsFourthConv = reader.Value;
                                    myQtrSummary.fourthConv = Convert.ToDecimal(reader.Value);
                                    reader.MoveToAttribute("fourthatt");
                                    //qtrSummaryConversionsFourthAtt = reader.Value;
                                    myQtrSummary.fourthAtt = Convert.ToDecimal(reader.Value);
                                    //output.AppendLine("Conversions: ");
                                    //output.AppendLine("  ---3rd down: " + myQtrSummary.TeamThirdConv + "-" + myQtrSummary.TeamThirdAtt);
                                    //output.AppendLine("  ---4th down: " + myQtrSummary.TeamFourthConv + "-" + myQtrSummary.TeamFourthAtt);

                                }
                                if (reader.Name == "fumbles")
                                {
                                    reader.MoveToAttribute("no");
                                    //qtrSummaryFumblesNo = reader.Value;
                                    myQtrSummary.fumblesNo = Convert.ToDecimal(reader.Value);
                                    reader.MoveToAttribute("lost");
                                    //qtrSummaryFumblesLost = reader.Value;
                                    myQtrSummary.fumblesLost = Convert.ToDecimal(reader.Value);
                                    //output.AppendLine("Fumbles: " + myQtrSummary.TeamFumbles);
                                    //output.AppendLine("  ---Lost: " + myQtrSummary.TeamFumblesLost);
                                }
                                if (reader.Name == "misc")
                                {

                                    //output.AppendLine("Misc.: ");
                                    reader.MoveToFirstAttribute();

                                    for (int y = 0; y < miscNode.Attributes.Count; y++)
                                    {

                                        if (reader.Name == "yds")
                                        {
                                            //qtrSummaryMiscYds = reader.Value;
                                            myQtrSummary.miscYds = Convert.ToDecimal(reader.Value);
                                            //output.AppendLine("  ---Yds: " + myQtrSummary.TeamMiscYds);
                                        }
                                        if (reader.Name == "top")
                                        {
                                            myQtrSummary.timeOfPoss = reader.Value;
                                            //output.AppendLine("  ---T.O.P.: " + myQtrSummary.timeOfPoss);
                                        }
                                        if (reader.Name == "ona")
                                        {
                                            // qtrSummaryMiscOna = reader.Value;
                                            myQtrSummary.onsideAtt = Convert.ToDecimal(reader.Value);
                                            //output.AppendLine("  ---Onside Att.: " + myQtrSummary.onsideAtt);
                                        }
                                        if (reader.Name == "onm")
                                        {
                                            //qtrSummaryMiscOnm = reader.Value;
                                            myQtrSummary.onsideMade = Convert.ToDecimal(reader.Value);
                                            //output.AppendLine("  ---Onside Made: " + myQtrSummary.onsideMade);
                                        }
                                        if (reader.Name == "ptsto")
                                        {
                                            //qtrSummaryMiscPtsto = reader.Value;
                                            myQtrSummary.pointsOffTurnovers = Convert.ToDecimal(reader.Value);
                                            //output.AppendLine("  ---Pts Off Turnovers: " + myQtrSummary.pointsOffTurnovers);
                                        }

                                        reader.MoveToNextAttribute();
                                    }
                                }
                                if (reader.Name == "rush")
                                {
                                    reader.MoveToAttribute("att");
                                    //qtrSummaryRushAtt = reader.Value;
                                    myQtrSummary.rushAtt = Convert.ToDecimal(reader.Value);
                                    reader.MoveToAttribute("yds");
                                    //qtrSummaryRushYds = reader.Value;
                                    myQtrSummary.rushYds = Convert.ToDecimal(reader.Value);
                                    reader.MoveToAttribute("gain");
                                    //qtrSummaryRushGain = reader.Value;
                                    myQtrSummary.rushGain = Convert.ToDecimal(reader.Value);
                                    reader.MoveToAttribute("loss");
                                    //qtrSummaryRushLoss = reader.Value;
                                    myQtrSummary.rushLoss = Convert.ToDecimal(reader.Value);
                                    reader.MoveToAttribute("td");
                                    //qtrSummaryRushTd = reader.Value;
                                    myQtrSummary.rushTd = Convert.ToDecimal(reader.Value);
                                    reader.MoveToAttribute("long");
                                    //qtrSummaryRushLong = reader.Value;
                                    myQtrSummary.rushLong = Convert.ToDecimal(reader.Value);
                                    //output.AppendLine("Rushing: ");
                                    //output.AppendLine("  ---Attempts: " + myQtrSummary.rushAtt);
                                    //output.AppendLine("  ---Yds: " + myQtrSummary.rushYds);
                                    //output.AppendLine("  ---Gain: " + myQtrSummary.rushGain);
                                    //output.AppendLine("  ---Loss: " + myQtrSummary.rushLoss);
                                    //output.AppendLine("  ---TD: " + myQtrSummary.rushTd);
                                    //output.AppendLine("  ---Long: " + myQtrSummary.rushLong);
                                }
                                if (reader.Name == "pass")
                                {


                                    reader.MoveToAttribute("comp");
                                    //qtrSummaryPassComp = reader.Value;
                                    myQtrSummary.passComp = Convert.ToDecimal(reader.Value);
                                    reader.MoveToAttribute("att");
                                    //qtrSummaryPassAtt = reader.Value;
                                    myQtrSummary.passAtt = Convert.ToDecimal(reader.Value);
                                    reader.MoveToAttribute("int");
                                    //qtrSummaryPassInt = reader.Value;
                                    myQtrSummary.passInt = Convert.ToDecimal(reader.Value);
                                    reader.MoveToAttribute("yds");
                                    //qtrSummaryPassYds = reader.Value;
                                    myQtrSummary.passYds = Convert.ToDecimal(reader.Value);
                                    reader.MoveToAttribute("td");
                                    //qtrSummaryPassTd = reader.Value;
                                    myQtrSummary.passTd = Convert.ToDecimal(reader.Value);
                                    reader.MoveToAttribute("long");
                                    //qtrSummaryPassLong = reader.Value;
                                    myQtrSummary.passLong = Convert.ToDecimal(reader.Value);
                                    reader.MoveToAttribute("sacks");
                                    //qtrSummaryPassSacks = reader.Value;
                                    myQtrSummary.passSacks = Convert.ToDecimal(reader.Value);
                                    reader.MoveToAttribute("sackyds");
                                    //qtrSummaryPassSackYds = reader.Value;
                                    myQtrSummary.passSackYds = Convert.ToDecimal(reader.Value);
                                    //output.AppendLine("Passing: ");
                                    //output.AppendLine("  ---Completions: " + myQtrSummary.passComp);
                                    //output.AppendLine("  ---Attempts: " + myQtrSummary.passAtt);
                                    //output.AppendLine("  ---Interceptions: " + myQtrSummary.passInt);
                                    //output.AppendLine("  ---Yds: " + myQtrSummary.passYds);
                                    //output.AppendLine("  ---TD: " + myQtrSummary.passTd);
                                    //output.AppendLine("  ---Long: " + myQtrSummary.passLong);
                                    //output.AppendLine("  ---Sacks: " + myQtrSummary.passSacks);
                                    //output.AppendLine("  ---Sack Yds: " + myQtrSummary.passSackYds);
                                }

                                if (reader.Name == "rcv")
                                {


                                    reader.MoveToAttribute("no");
                                    //qtrSummaryRcvNo = reader.Value;
                                    myQtrSummary.rcvNo = Convert.ToDecimal(reader.Value);
                                    reader.MoveToAttribute("yds");
                                    //qtrSummaryRcvYds = reader.Value;
                                    myQtrSummary.rcvYds = Convert.ToDecimal(reader.Value);
                                    reader.MoveToAttribute("td");
                                    //qtrSummaryRcvTd = reader.Value;
                                    myQtrSummary.rcvTd = Convert.ToDecimal(reader.Value);
                                    reader.MoveToAttribute("long");
                                    //qtrSummaryRcvLong = reader.Value;
                                    myQtrSummary.rcvLong = Convert.ToDecimal(reader.Value);
                                    //output.AppendLine("Receiving: ");
                                    //output.AppendLine("  ---Number: " + myQtrSummary.rcvNo);
                                    //output.AppendLine("  ---Yds: " + myQtrSummary.rcvYds);
                                    //output.AppendLine("  ---TDs: " + myQtrSummary.rcvTd);
                                    //output.AppendLine("  ---Long: " + myQtrSummary.rcvLong);
                                }
                                //Put other tag logic here
                                if (reader.Name == "punt")
                                {


                                    reader.MoveToAttribute("no");
                                    // qtrSummaryPuntNo = reader.Value;
                                    myQtrSummary.puntNo = Convert.ToDecimal(reader.Value);
                                    reader.MoveToAttribute("yds");
                                    //qtrSummaryPuntYds = reader.Value;
                                    myQtrSummary.puntYds = Convert.ToDecimal(reader.Value);
                                    reader.MoveToAttribute("long");
                                    //qtrSummaryPuntLong = reader.Value;
                                    myQtrSummary.puntLong = Convert.ToDecimal(reader.Value);
                                    reader.MoveToAttribute("blkd");
                                    //qtrSummaryPuntBlkd = reader.Value;
                                    myQtrSummary.puntBlkd = Convert.ToDecimal(reader.Value);
                                    reader.MoveToAttribute("tb");
                                    //qtrSummaryPuntTb = reader.Value;
                                    myQtrSummary.puntTb = Convert.ToDecimal(reader.Value);
                                    reader.MoveToAttribute("fc");
                                    // qtrSummaryPuntFc = reader.Value;
                                    myQtrSummary.puntFc = Convert.ToDecimal(reader.Value);
                                    reader.MoveToAttribute("plus50");
                                    //qtrSummaryPuntPlus50 = reader.Value;
                                    myQtrSummary.puntPlus50 = Convert.ToDecimal(reader.Value);
                                    reader.MoveToAttribute("inside20");
                                    //qtrSummaryPuntInside20 = reader.Value;
                                    myQtrSummary.puntInside20 = Convert.ToDecimal(reader.Value);

                                    //output.AppendLine("Punting: ");
                                    //output.AppendLine("  ---Number: " + myQtrSummary.puntNo);
                                    //output.AppendLine("  ---Yds: " + myQtrSummary.puntYds);
                                    //output.AppendLine("  ---Long: " + myQtrSummary.puntLong);
                                    //output.AppendLine("  ---Punts Blocked: " + myQtrSummary.puntBlkd);
                                    //output.AppendLine("  ---Punts TB?: " + myQtrSummary.puntTb);
                                    //output.AppendLine("  ---Punts Fc: " + myQtrSummary.puntFc);
                                    //output.AppendLine("  ---Punts plus50: " + myQtrSummary.puntPlus50);
                                    //output.AppendLine("  ---Punts inside the 20: " + myQtrSummary.puntInside20);
                                }
                                if (reader.Name == "ko")
                                {


                                    reader.MoveToAttribute("no");
                                    //qtrSummaryKoNo = reader.Value;
                                    myQtrSummary.koNo = Convert.ToDecimal(reader.Value);
                                    reader.MoveToAttribute("yds");
                                    //qtrSummaryKoYds = reader.Value;
                                    myQtrSummary.koYds = Convert.ToDecimal(reader.Value);
                                    reader.MoveToAttribute("ob");
                                    //qtrSummaryKoOb = reader.Value;
                                    myQtrSummary.koOb = Convert.ToDecimal(reader.Value);
                                    reader.MoveToAttribute("tb");
                                    //qtrSummaryKoTb = reader.Value;
                                    myQtrSummary.koTb = Convert.ToDecimal(reader.Value);
                                    //output.AppendLine("Kickoffs: ");
                                    //output.AppendLine("  ---Kickoffs: " + myQtrSummary.koNo);
                                    //output.AppendLine("  ---Kickoff Yards: " + myQtrSummary.koYds);
                                    //output.AppendLine("  ---Kickoffs OB: " + myQtrSummary.koOb);
                                    //output.AppendLine("  ---Touchbacks: " + myQtrSummary.koTb);
                                }
                                if (reader.Name == "fg")
                                {
                                    reader.MoveToAttribute("made");
                                    // qtrSummaryFgMade = reader.Value;
                                    myQtrSummary.fgMade = Convert.ToDecimal(reader.Value);
                                    reader.MoveToAttribute("att");
                                    // qtrSummaryFgAtt = reader.Value;
                                    myQtrSummary.fgAtt = Convert.ToDecimal(reader.Value);
                                    reader.MoveToAttribute("long");
                                    //qtrSummaryFgLong = reader.Value;
                                    myQtrSummary.fgLong = Convert.ToDecimal(reader.Value);
                                    reader.MoveToAttribute("blkd");
                                    //qtrSummaryFgBlkd = reader.Value;
                                    myQtrSummary.fgBlkd = Convert.ToDecimal(reader.Value);
                                    //output.AppendLine("  ---Field Goal Attempts: " + myQtrSummary.fgAtt);
                                    //output.AppendLine("  ---Field Goal Long: " + myQtrSummary.fgLong);
                                    //output.AppendLine("  ---Field Goals Blocked: " + myQtrSummary.fgBlkd);
                                    //output.AppendLine("  ---Field Goals Made: " + myQtrSummary.fgMade);
                                }

                                if (reader.Name == "pat")
                                {

                                    reader.MoveToAttribute("kickatt");
                                    //qtrSummaryPatKickAtt = reader.Value;
                                    myQtrSummary.patKickAtt = Convert.ToDecimal(reader.Value);
                                    reader.MoveToAttribute("kickmade");
                                    //qtrSummaryPatKickMade = reader.Value;
                                    myQtrSummary.patKickMade = Convert.ToDecimal(reader.Value);
                                    //output.AppendLine("PAT: ");
                                    //output.AppendLine("  ---PAT Attempts: " + myQtrSummary.patKickAtt);
                                    //output.AppendLine("  ---PAT Made: " + myQtrSummary.patKickMade);
                                }
                                if (reader.Name == "defense")
                                {


                                    output.AppendLine("Defense:");

                                    reader.MoveToFirstAttribute();

                                    for (int y = 0; y < defenseNode.Attributes.Count; y++)
                                    {

                                        if (reader.Name == "tackua")
                                        {
                                            //defTackUa = reader.Value;
                                            myQtrSummary.defTackUA = Convert.ToDecimal(reader.Value);
                                            //output.AppendLine("  ---Tackles(UA): " + myQtrSummary.defTackUA);
                                        }
                                        if (reader.Name == "tacka")
                                        {
                                            //defTackA = reader.Value;
                                            myQtrSummary.defTackA = Convert.ToDecimal(reader.Value);
                                            //output.AppendLine("  ---Tackles(A): " + myQtrSummary.defTackA);
                                        }
                                        if (reader.Name == "tflua")
                                        {
                                            //defTflUa = reader.Value;
                                            myQtrSummary.defTflUA = Convert.ToDecimal(reader.Value);
                                            //output.AppendLine("  ---TFL(UA): " + myQtrSummary.defTflUA);
                                        }
                                        if (reader.Name == "tfla")
                                        {
                                            //defTflA = reader.Value;
                                            myQtrSummary.defTflA = Convert.ToDecimal(reader.Value);
                                            //output.AppendLine("  ---TFL(A): " + myQtrSummary.defTflA);
                                        }
                                        if (reader.Name == "tflyds")
                                        {
                                            //defTflYds = reader.Value;
                                            myQtrSummary.defTflYards = Convert.ToDecimal(reader.Value);
                                            //output.AppendLine("  ---TFL Yds: " + myQtrSummary.defTflYards);
                                        }
                                        if (reader.Name == "sacks")
                                        {
                                            //defSacks = reader.Value;
                                            myQtrSummary.defSacks = Convert.ToDecimal(reader.Value);
                                            //output.AppendLine("  ---Sacks: " + myQtrSummary.defSacks);
                                        }
                                        if (reader.Name == "sackyds")
                                        {
                                            //defSackYds = reader.Value;
                                            myQtrSummary.defSackYds = Convert.ToDecimal(reader.Value);
                                            //output.AppendLine("  ---Sack Yds: " + myQtrSummary.defSackYds);
                                        }
                                        if (reader.Name == "brup")
                                        {
                                            //defBrup = reader.Value;
                                            myQtrSummary.defBrup = Convert.ToDecimal(reader.Value);
                                            //output.AppendLine("  ---Pass Breakups: " + myQtrSummary.defBrup);
                                        }
                                        if (reader.Name == "qbh")
                                        {
                                            //defQbh = reader.Value;
                                            myQtrSummary.defQbh = Convert.ToDecimal(reader.Value);
                                            //output.AppendLine("  ---QB Hurries: " + myQtrSummary.defQbh);
                                        }
                                        //TODO: Update this code block with the myQtrSummary.defBlkd field
                                        if (reader.Name == "blkd")
                                        {
                                            defBlkd = reader.Value;
                                            //myDefense.Bl = Convert.ToDecimal(reader.Value);
                                            //output.AppendLine("  ---Kicks Blkd.: " + defBlkd);
                                        }
                                        if (reader.Name == "ff")
                                        {
                                            //defFf = reader.Value;
                                            myQtrSummary.defFf = Convert.ToDecimal(reader.Value);
                                            //output.AppendLine("  ---Fumbles Forced: " + myQtrSummary.defFf);
                                        }
                                        if (reader.Name == "fr")
                                        {
                                            //defFr = reader.Value;
                                            myQtrSummary.defFr = Convert.ToDecimal(reader.Value);
                                            //output.AppendLine("  ---Fumbles Recovered: " + myQtrSummary.defFr);
                                        }
                                        if (reader.Name == "int")
                                        {
                                            //defInt = reader.Value;
                                            myQtrSummary.defInts = Convert.ToDecimal(reader.Value);
                                            output.AppendLine("  ---Interceptions: " + myQtrSummary.defInts);
                                        }
                                        if (reader.Name == "intyds")
                                        {
                                            //defIntYds = reader.Value;
                                            myQtrSummary.defIntYds = Convert.ToDecimal(reader.Value);
                                            //output.AppendLine("  ---Int. Yds: " + myQtrSummary.defIntYds);
                                        }

                                        reader.MoveToNextAttribute();
                                    }

                                }
                                if (reader.Name == "kr")
                                {
                                    reader.MoveToAttribute("no");
                                    //qtrSummaryKrNo = reader.Value;
                                    myQtrSummary.krNo = Convert.ToDecimal(reader.Value);
                                    reader.MoveToAttribute("yds");
                                    //qtrSummaryKrYds = reader.Value;
                                    myQtrSummary.krYds = Convert.ToDecimal(reader.Value);
                                    reader.MoveToAttribute("td");
                                    //qtrSummaryKrTd = reader.Value;
                                    myQtrSummary.krTd = Convert.ToDecimal(reader.Value);
                                    reader.MoveToAttribute("long");
                                    //qtrSummaryKrLong = reader.Value;
                                    myQtrSummary.krLong = Convert.ToDecimal(reader.Value);
                                    //output.AppendLine("Kick Returns: ");
                                    //output.AppendLine("  ---Kick Return TD: " + myQtrSummary.krTd);
                                    //output.AppendLine("  ---Kick Return Yards: " + myQtrSummary.krYds);
                                    //output.AppendLine("  ---Kick Return Attempts: " + myQtrSummary.krNo);
                                    //output.AppendLine("  ---Kick Return Long: " + myQtrSummary.krLong);


                                }
                                if (reader.Name == "pr")
                                {


                                    reader.MoveToAttribute("no");
                                    //qtrSummaryPrNo = reader.Value;
                                    myQtrSummary.prNo = Convert.ToDecimal(reader.Value);
                                    reader.MoveToAttribute("yds");
                                    //qtrSummaryPrYds = reader.Value;
                                    myQtrSummary.prYds = Convert.ToDecimal(reader.Value);
                                    reader.MoveToAttribute("td");
                                    //qtrSummaryPrTd = reader.Value;
                                    myQtrSummary.prTd = Convert.ToDecimal(reader.Value);
                                    reader.MoveToAttribute("long");
                                    //qtrSummaryPrLong = reader.Value;
                                    myQtrSummary.prLong = Convert.ToDecimal(reader.Value);
                                    //output.AppendLine("Punt Returns: ");
                                    //output.AppendLine("  ---Punt Return TD: " + myQtrSummary.prTd);
                                    //output.AppendLine("  ---Punt Return Yards: " + myQtrSummary.prYds);
                                    //output.AppendLine("  ---Punt Return Attempts: " + myQtrSummary.prNo);
                                    //output.AppendLine("  ---Punt Return Long: " + myQtrSummary.prLong);

                                }
                                if (reader.Name == "scoring")
                                {
                                    //output.AppendLine("Scoring: ");
                                    reader.MoveToFirstAttribute();

                                    for (int y = 0; y < scoringNode.Attributes.Count; y++)
                                    {

                                        if (reader.Name == "td")
                                        {
                                            //qtrSummaryScoringTd = reader.Value;
                                            myQtrSummary.scoringTD = Convert.ToDecimal(reader.Value);
                                            //output.AppendLine("  ---TD: " + myQtrSummary.scoringTD);
                                        }
                                        if (reader.Name == "fg")
                                        {
                                            //qtrSummaryScoringFg = reader.Value;
                                            myQtrSummary.scoringFG = Convert.ToDecimal(reader.Value);
                                            //output.AppendLine("  ---FG: " + myQtrSummary.scoringFG);
                                        }
                                        if (reader.Name == "patkick")
                                        {
                                            //qtrSummaryScoringPatKick = reader.Value;
                                            myQtrSummary.scoringPatKick = Convert.ToDecimal(reader.Value);
                                            //output.AppendLine("  ---PAT Kick: " + myQtrSummary.scoringPatKick);
                                        }
                                        if (reader.Name == "patrush")
                                        {
                                            //qtrSummaryScoringPatRush = reader.Value;
                                            myQtrSummary.scoringPatRush = Convert.ToDecimal(reader.Value);
                                            //output.AppendLine("  ---PAT Rush: " + myQtrSummary.scoringPatRush);
                                        }
                                        if (reader.Name == "patrcv")
                                        {
                                            //qtrSummaryScoringPatRcv = reader.Value;
                                            myQtrSummary.scoringPatRcv = Convert.ToDecimal(reader.Value);
                                            //output.AppendLine("  ---PAT Rcv: " + myQtrSummary.scoringPatRcv);
                                        }
                                        if (reader.Name == "saf")
                                        {
                                            //qtrSummaryScoringSaf = reader.Value;
                                            myQtrSummary.scoringSaf = Convert.ToDecimal(reader.Value);
                                            //output.AppendLine("  ---Safeties: " + myQtrSummary.scoringSaf);
                                        }

                                        reader.MoveToNextAttribute();
                                    }
                                }
                                if (reader.Name == "ir")
                                {
                                    reader.MoveToAttribute("no");
                                    //qtrSummaryIrNo = reader.Value;
                                    myQtrSummary.irNo = Convert.ToDecimal(reader.Value);
                                    reader.MoveToAttribute("yds");
                                    //qtrSummaryIrYds = reader.Value;
                                    myQtrSummary.irYds = Convert.ToDecimal(reader.Value);
                                    reader.MoveToAttribute("td");
                                    // qtrSummaryIrTd = reader.Value;
                                    myQtrSummary.irTd = Convert.ToDecimal(reader.Value);
                                    reader.MoveToAttribute("long");
                                    //qtrSummaryIrLong = reader.Value;     
                                    myQtrSummary.irLong = Convert.ToDecimal(reader.Value);
                                    //output.AppendLine("  ---Int Return TD: " + myQtrSummary.irTd);
                                    //output.AppendLine("  ---Int Return Yards: " + myQtrSummary.irYds);
                                    //output.AppendLine("  ---Int Return Attempts: " + myQtrSummary.irNo);
                                    //output.AppendLine("  ---Int Return Long: " + myQtrSummary.irLong);
                                }

                            }
                        }
                        if (myQtrSummary.vh == "H")
                            myQtrSummary.teamGame_Id = homeTeamGame.teamGame_Id;
                        if (myQtrSummary.vh=="V")
                            myQtrSummary.teamGame_Id = visTeamGame.teamGame_Id;

                        db.QtrSummaries.Add(myQtrSummary);
                        db.SaveChanges();
                        checkQtrSummaryCount++;
                        z++;

                        qtrCount = qtrCount + .5;
                    }
                    #endregion


                    //longplays
                    longplayNode = doc.SelectSingleNode("/fbgame/longplays");
                    int longplayCount = longplayNode.ChildNodes.Count;

                    reader.ReadToFollowing("longplays");
                    reader.MoveToAttribute("thresh");
                    longplayThresh = reader.Value;

                    //output.AppendLine("Long Plays (" + longplayThresh + "yds+)" + ": ");

                    for (int x = 0; x < longplayCount; x++)
                    {
                        longPlay = new LongPlay();

                        longPlay.thresh = longplayThresh;

                        reader.ReadToFollowing("longplay");
                        reader.MoveToAttribute("vh");
                        longPlay.vh = reader.Value;
                        reader.MoveToAttribute("id");
                        longPlay.team = reader.Value;
                        reader.MoveToAttribute("yds");
                        longPlay.yds = Convert.ToDecimal(reader.Value);
                        reader.MoveToAttribute("play");
                        longPlay.play = reader.Value;
                        reader.MoveToAttribute("players");
                        longPlay.players = reader.Value;
                        reader.MoveToAttribute("td");
                        longPlay.td = reader.Value;

                        longPlay.Game_Id = game.game_Id;

                        db.LongPlays.Add(longPlay);
                        db.SaveChanges();
                        //output.AppendLine("  " + longplayVh + " " + longplayId + " " + longplayYds + " " + longplayPlay + " " + longplayPlayers + " " + longplayTd);
                    }
                    //}

                    //ViewBag.Game = output;
                }

                db.SaveChanges();
            }

            //Console.Write(output);
            //Console.ReadLine();

            //System.IO.File.WriteAllText(@"C:\Users\rharrison15\Desktop\OutputGameFile.txt", output.ToString());

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}