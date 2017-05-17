using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Projets_MDL
{
    class ModeleBDD
    {
        private string connectionString;

        public ModeleBDD()
        {
            Initialize();
        }

        private void Initialize()
        {
            string server = "localhost";
            string port = "3306";
            string database = "gestion_clubs";
            string uid = "root";
            string password = "";
            connectionString = "SERVER=" + server + ";" + "PORT=" + port + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
        }
 
        //La methode est modifié //club
        /// <summary>
        /// Methode qui selection tous clubs sur la base de données
        /// </summary>
        /// <returns>Return un Listes des clubs</returns>
        public List<Clubs> getClubs()
        {
            List<Clubs> lesClubs = new List<Clubs>();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT c.id AS IdClub, c.Nom, c.LienSIte, c.Adresse, c.Ville, c.CodePostal, c.Telephone, c.Email, c.id_type, t.id AS IdType, t.Libelle From clubs AS c INNER JOIN type AS t ON c.id_type = t.id";

                //Crée Commande
                MySqlCommand command = new MySqlCommand(query, connection);
                //On crée un datareader et on execute la commande
                using (MySqlDataReader dataReader = command.ExecuteReader())
                {
                    //On li la base de données et on ajiute dans la liste les ahderents de la base de données
                    while (dataReader.Read())
                    {
                        TypeClub Type = new TypeClub();
                        Type.setId((int)dataReader["IdType"]);
                        Type.setLibelle((string)dataReader["Libelle"]);

                        Clubs lClub = new Clubs();
                        lClub.setId((int)dataReader["IdClub"]);
                        lClub.setLienSite((string)dataReader["LienSite"]);
                        lClub.setMail((string)dataReader["Email"]);
                        lClub.setNom((string)dataReader["Nom"]);
                        lClub.setType(Type);
                        lClub.setTel((int)dataReader["Telephone"]);
                        lClub.setAdresse((string)dataReader["Adresse"]);
                        lClub.setCPT((int)dataReader["CodePostal"]);
                        lClub.setVille((string)dataReader["Ville"]);
                        
                        lesClubs.Add(lClub);
                    }

                }

                connection.Close();

                return lesClubs;
                
            }
        }

        /// <summary>
        /// methode setClub ajouter un club dans la base dedonnées
        /// </summary>
        /// <param name="leClub">est un abjet de la classe Clubs</param>
        public void setClub(Clubs leClub)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "INSERT INTO clubs(Nom, LienSite, Adresse, Ville, CodePostal, Telephone, Email, id_type) VALUES (@Nom, @LienSite, @Adresse, @Ville, @CodePostal, @Telephone, @Email, (SELECT id FROM Type WHERE Libelle = @Type))";
                command.Parameters.AddWithValue("@Nom", leClub.getNom());
                command.Parameters.AddWithValue("@LienSite", leClub.getLienSite());
                command.Parameters.AddWithValue("@Adresse", leClub.getAdresse());
                command.Parameters.AddWithValue("@Ville", leClub.getVille());
                command.Parameters.AddWithValue("@CodePostal", leClub.getCPT());
                command.Parameters.AddWithValue("@Telephone", leClub.getTel());
                command.Parameters.AddWithValue("@Email", leClub.getEMail());
                command.Parameters.AddWithValue("@Type", leClub.getType().getLibelle());
                command.ExecuteNonQuery();
                connection.Close();
                
            }
        }

        /// <summary>
        /// Methode qui permet de supprimer un club de la base de données
        /// </summary>
        /// <param name="club">L'ID du club a supprimer de la base de données</param>
        public void subClub(int club)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "DELETE FROM clubs WHERE id=@id";

                //on crée la commande
                MySqlCommand command = new MySqlCommand(query, connection);

                command.Parameters.AddWithValue("@id", club);
                command.ExecuteNonQuery();

                connection.Close();
            }
        }

        /// <summary>
        /// La méthode modifie un club en fonction de l'objet Clubs en parametre. 
        /// </summary>
        /// <param name="Clubs">Leclub a modifié </param>
        /// <returns>un club</returns>
        public void UPDATEClub(Clubs leClub)
        {

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "UPDATE clubs SET Nom=@Nom, LienSite=@LienSite, Adresse=@Adresse, Ville=@Ville, CodePostal=@CodePostal, Telephone=@Telephone, Email=@Email, id_type= ( SELECT id FROM type WHERE Libelle=@Type ) WHERE id=@id";
                command.Parameters.AddWithValue("@Id", leClub.getId());
                command.Parameters.AddWithValue("@Nom", leClub.getNom());
                command.Parameters.AddWithValue("@LienSite", leClub.getLienSite());
                command.Parameters.AddWithValue("@Adresse", leClub.getAdresse());
                command.Parameters.AddWithValue("@Ville", leClub.getVille());
                command.Parameters.AddWithValue("@CodePostal", leClub.getCPT());
                command.Parameters.AddWithValue("@Telephone", leClub.getTel());
                command.Parameters.AddWithValue("@Email", leClub.getEMail());
                command.Parameters.AddWithValue("@Type", leClub.getType().getLibelle());
                command.ExecuteNonQuery();
                connection.Close();
            }

          
        }

        //La methode est modifié //typeclub
        /// <summary>
        /// Methode qui selection tous Typeclub de la base de données
        /// </summary>
        /// <returns>Return une Liste de Typeclub</returns>
        public List<TypeClub> getTypeClub()
        {
            List<TypeClub> lesTypeClub = new List<TypeClub>();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * From type";

                //Crée Commande
                MySqlCommand command = new MySqlCommand(query, connection);
                //On crée un datareader et on execute la commande
                using (MySqlDataReader dataReader = command.ExecuteReader())
                {
                    //On li la base de données et on ajoute dans la liste les TypeClub de la base
                    while (dataReader.Read())
                    {
                        TypeClub Type = new TypeClub();
                        Type.setId((int)dataReader["Id"]);
                        Type.setLibelle((string)dataReader["Libelle"]);

                        

                        lesTypeClub.Add(Type);
                    }

                }

                connection.Close();

                return lesTypeClub;

            }
        }

        public void setTypeSport(TypeClub Type)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "INSERT INTO type(Libelle) VALUES (@Libelle)";
                command.Parameters.AddWithValue("@Libelle", Type.getLibelle());
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void supTypeSport(TypeClub type)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "DELETE FROM type WHERE Libelle=@Libelle";

                //on crée la commande
                MySqlCommand command = new MySqlCommand(query, connection);

                command.Parameters.AddWithValue("@Libelle", type.getLibelle());
                command.ExecuteNonQuery();

                connection.Close();
            }
        }

        //les sont modifié //adherent
        /// <summary>
        /// Methode qui selection tous adhernts sur la base de données
        /// </summary>
        /// <returns>Return un Listes des adherents</returns>
        public List<Adherents> getAdherents()
        {
            List<Adherents> lesAdherents = new List<Adherents>();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT a.id AS IdAdherent, a.Licence, a.Sexe, a.Nom, a.Prenom, a.Naissance, a.Adresse, a.CodePostal, a.Ville, a.Cotisation, c.id AS IdClub, c.Nom AS NomClub FROM adherents AS a INNER JOIN clubs AS c ON a.id_clubs=c.id";
                
                //Crée Commande
                MySqlCommand command = new MySqlCommand(query, connection);
                //On crée un datareader et on execute la commande
                using (MySqlDataReader dataReader = command.ExecuteReader())
                {
                    
                    //On li la base de données et on ajoute dans la liste les ahderents de la base de données
                    while (dataReader.Read())
                    {
                        Clubs club = new Clubs();
                        club.setId((int)dataReader["IdClub"]);
                        club.setNom((string)dataReader["NomClub"]);
                        Adherents lAdherent = new Adherents();
                        lAdherent.setId((int)dataReader["IdAdherent"]);
                        lAdherent.setClub(club);
                        lAdherent.setLicence((string)dataReader["Licence"]);
                        lAdherent.setSexe((string)dataReader["Sexe"]);
                        lAdherent.setNom((string)dataReader["Nom"]);
                        lAdherent.setPrenom((string)dataReader["Prenom"]);
                        lAdherent.setNaissance((DateTime)dataReader["Naissance"]);
                        lAdherent.setAdresse((string)dataReader["Adresse"]);
                        lAdherent.setCPT((int)dataReader["CodePostal"]);
                        lAdherent.setVille((string)dataReader["Ville"]);
                        lAdherent.setCotisation((int)dataReader["Cotisation"]);

                        lesAdherents.Add(lAdherent);
                    }
                    //string MySQLFormatDate = dateValue.ToString("yyyy-MM-dd HH:mm:ss")
                }

                connection.Close();

                return lesAdherents;


            }

        }

        /// <summary>
        /// methode setAdherents ajouter un adherents dans un base de donnée
        /// </summary>
        /// <param name="me">est un objet de la classe Adherents</param>
        public void setAdherent(Adherents me)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "INSERT INTO adherents(id_clubs, Licence, Sexe, Nom, Prenom, Naissance, Adresse, CodePostal, Ville, Cotisation) VALUES ((SELECT id FROM clubs WHERE Nom = @Club), @Licence, @Sexe, @Nom, @Prenom, @Naissance, @Adresse, @CodePostal, @Ville, @Cotisation)";
                command.Parameters.AddWithValue("@Club", me.getClub().getNom());
                command.Parameters.AddWithValue("@Licence", me.getLicence());
                command.Parameters.AddWithValue("@Sexe", me.getSexe());
                command.Parameters.AddWithValue("@Nom", me.getNom());
                command.Parameters.AddWithValue("@Prenom", me.getPrenom());
                command.Parameters.AddWithValue("@Naissance", me.getNaissance());
                command.Parameters.AddWithValue("@Adresse", me.getAdresse());
                command.Parameters.AddWithValue("@CodePostal", me.getCPT());
                command.Parameters.AddWithValue("@Ville", me.getVille());
                command.Parameters.AddWithValue("@Cotisation", me.getCotisation());
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        /// <summary>
        /// Methode qui permet de supprimer un adherents de la base de données
        /// </summary>
        /// <param name="nom">Le nom de l'adherent a supprimer de la table</param>
        public void supAdherents(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "DELETE FROM adherents WHERE id=@id";

                //on crée la commande
                MySqlCommand command = new MySqlCommand(query, connection);

                command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();

                connection.Close();
            }
        }

        /// <summary>
        /// Methode qui permet de modifié un adhérent dans la base de donnée
        /// </summary>
        /// <param name="lAdherent">lAdherent a modifié</param>
        public void UPDATEAdherent(Adherents lAdherent)
        {

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "UPDATE adherents SET id_clubs=(SELECT id FROM clubs WHERE Nom=@NomClub), Licence=@Licence, Sexe=@Sexe, Nom=@Nom, Prenom=@Prenom, Naissance=@Naissance, Adresse=@Adresse, CodePostal=@CodePostal, Ville=@Ville,  Cotisation=@Cotisation WHERE id=@id";
                command.Parameters.AddWithValue("@Id", lAdherent.getId());
                command.Parameters.AddWithValue("@NomClub", lAdherent.getClub().getNom());
                command.Parameters.AddWithValue("@Licence", lAdherent.getLicence());
                command.Parameters.AddWithValue("@Nom", lAdherent.getNom());
                command.Parameters.AddWithValue("@Prenom", lAdherent.getPrenom());
                command.Parameters.AddWithValue("@Sexe", lAdherent.getSexe());
                command.Parameters.AddWithValue("@Naissance", lAdherent.getNaissance());
                command.Parameters.AddWithValue("@CodePostal", lAdherent.getCPT());
                command.Parameters.AddWithValue("@Adresse", lAdherent.getAdresse());
                command.Parameters.AddWithValue("@Ville", lAdherent.getVille());
                command.Parameters.AddWithValue("@Cotisation", lAdherent.getCotisation());
                command.ExecuteNonQuery();
                connection.Close();
            }


        }

        public List<Adherents> VerifLicence()
        {
            List<Adherents> lesAdherents = new List<Adherents>();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT Licence from adherents";

                //Crée Commande
                MySqlCommand command = new MySqlCommand(query, connection);
                //On crée un datareader et on execute la commande
                using (MySqlDataReader dataReader = command.ExecuteReader())
                {

                    //On li la base de données et on ajoute dans la liste les ahderents
                    while (dataReader.Read())
                    {

                        Adherents lAdherent = new Adherents();

                        lAdherent.setLicence((string)dataReader["Licence"]);

                        lesAdherents.Add(lAdherent);
                    }
                    //string MySQLFormatDate = dateValue.ToString("yyyy-MM-dd HH:mm:ss")
                }

                connection.Close();
            }
                return lesAdherents;
        }
        /* /// <summary>
         /// La méthode Read retourne un Adherent en fonction de l'id en parametre. 
         /// </summary>
         /// <param name="id">id de l'adherent selectionnedans la dataGridView</param>
         /// <returns>un adhrent</returns>
         public Adherents Read(int id)
         {
             Adherents lAdherent = null;

             using (MySqlConnection connection = new MySqlConnection(connectionString))
             {
                 connection.Open();
                 string query = "SELECT * FROM adherents where id=@id";

                 //Create Command
                 MySqlCommand cmd = new MySqlCommand(query, connection);

                 cmd.Parameters.AddWithValue("@id", id);

                 //Create a data reader and Execute the command
                 using (MySqlDataReader dataReader = cmd.ExecuteReader())
                 {
                     //Read the data and store them in the list
                     while (dataReader.Read())
                     {
                         lAdherent = new Adherents();
                         lAdherent.setId((int)dataReader["id"]);
                         lAdherent.setLicence((string)dataReader["Licence"]);
                         lAdherent.setNom((string)dataReader["Nom"]);
                         lAdherent.setPrenom((string)dataReader["Prenom"]);
                         lAdherent.setNaissance((string)dataReader["Naissance"]);
                         lAdherent.setAdresse((string)dataReader["Adresse"]);
                         lAdherent.setCPT((int)dataReader["CodePoastal"]);
                         lAdherent.setVille((string)dataReader["Ville"]);
                         lAdherent.setCotisation(dataReader["Cotisation"] != DBNull.Value ? (int)dataReader["Cotisation"] : 0);
                     }
                 }
             }

             return lAdherent;
         } */

        //methode evenement
        /// <summary>
        /// Methode qui selection tous Evenements sur la base de données
        /// </summary>
        /// <returns>Return un Listes des evenements</returns>
        public List<Evenements> getEvent()
        {
            List<Evenements> Events = new List<Evenements>();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT e.id AS IdEven, e.Titre, e.LienSite, e.Adresse, e.Ville, e.CodePostal, e.Moment, e.Type, e.id_clubs, c.id AS IdClub, c.Nom From evenements AS e INNER JOIN Clubs AS c ON e.id_clubs = c.id ORDER BY e.id ";

                //Crée Commande
                MySqlCommand command = new MySqlCommand(query, connection);
                //On crée un datareader et on execute la commande
                using (MySqlDataReader dataReader = command.ExecuteReader())
                {
                    //On li la base de données et on ajiute dans la liste les ahderents de la base de données
                    while (dataReader.Read())
                    {
                        Clubs LeClub = new Clubs();
                        LeClub.setId((int)dataReader["IdClub"]);
                        LeClub.setNom((string)dataReader["Nom"]);

                        Evenements Event = new Evenements();
                        Event.setId((int)dataReader["IdEven"]);
                        Event.setLienSite((string)dataReader["LienSite"]);
                        Event.setType((string)dataReader["Type"]);
                        Event.setTitre((string)dataReader["Titre"]);
                        Event.setClub(LeClub);
                        Event.setMoment((DateTime)dataReader["Moment"]);
                        Event.setAdresse((string)dataReader["Adresse"]);
                        Event.setCPT((int)dataReader["CodePostal"]);
                        Event.setVille((string)dataReader["Ville"]);

                        Events.Add(Event);
                    }

                }

                connection.Close();

                return Events;

            }
        }

        /// <summary>
        /// methode setEvent ajouter un evenements dans un base de donnée
        /// </summary>
        /// <param name="me">est un objet de la classe Evenements</param>
        public void setEvent(Evenements me)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "INSERT INTO evenements(id_clubs, Titre, Type, LienSite, Adresse, Ville, CodePostal, Moment) VALUES ((SELECT id FROM clubs WHERE Nom = @Club), @Titre, @Type, @LienSite, @Adresse, @Ville, @CodePostal, @Moment)";
                command.Parameters.AddWithValue("@Club", me.getClub().getNom());
                command.Parameters.AddWithValue("@Titre", me.getTitre());
                command.Parameters.AddWithValue("@Type", me.getType());
                command.Parameters.AddWithValue("@LienSite", me.getLienSite());
                command.Parameters.AddWithValue("@Adresse", me.getAdresse());
                command.Parameters.AddWithValue("@Ville", me.getVille());
                command.Parameters.AddWithValue("@CodePostal", me.getCPT());
                command.Parameters.AddWithValue("@Moment", me.getMoment());
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        /// <summary>
        /// Methode qui permet de supprimer un evenement de la base de données
        /// </summary>
        /// <param name="id">L'id de l'evenement a supprimer de la table</param>
        public void supEvent(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "DELETE FROM evenements WHERE id=@id";

                //on crée la commande
                MySqlCommand command = new MySqlCommand(query, connection);

                command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();

                connection.Close();
            }
        }

        /// <summary>
        /// Methode qui permet de modifié les information dans la base de donnée
        /// </summary>
        /// <param name="Event">Event a modifié</param>
        public void UPDATEEvent(Evenements Event)
        {

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "UPDATE evenements SET id_clubs=(SELECT id FROM clubs WHERE Nom=@NomClub), Titre=@Titre, Type=@Type, LienSite=@LienSite, Adresse=@Adresse, Ville=@Ville, CodePostal=@CodePostal, Moment=@Moment WHERE id=@id";
                command.Parameters.AddWithValue("@Id", Event.getId());
                command.Parameters.AddWithValue("@NomClub", Event.getClub().getNom());
                command.Parameters.AddWithValue("@Titre", Event.getTitre());
                command.Parameters.AddWithValue("@Type", Event.getType());
                command.Parameters.AddWithValue("@LienSite", Event.getLienSite());
                command.Parameters.AddWithValue("@Adresse", Event.getAdresse());
                command.Parameters.AddWithValue("@Ville", Event.getVille());
                command.Parameters.AddWithValue("@CodePostal", Event.getCPT());
                command.Parameters.AddWithValue("@Moment", Event.getMoment());
                command.ExecuteNonQuery();
                connection.Close();
            }


        }

        
    }
}
