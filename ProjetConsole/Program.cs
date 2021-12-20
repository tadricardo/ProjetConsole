using ProjetDLL;
using ProjetDLL.ConceptsObjets.Classes;
using ProjetDLL.ConceptsObjets.Encapsulation;
using ProjetDLL.ConceptsObjets.Quizzs;
using ProjetDLL.Delegates;
using ProjetDLL.DesignPatterns.Comportement.ChainOfResponsability;
using ProjetDLL.DesignPatterns.Comportement.Memento;
using ProjetDLL.DesignPatterns.Comportement.Observer;
using ProjetDLL.DesignPatterns.Creation.Builder;
using ProjetDLL.DesignPatterns.Creation.Factory;
using ProjetDLL.DesignPatterns.Creation.Prototype;
using ProjetDLL.DesignPatterns.Creation.Singleton;
using ProjetDLL.DesignPatterns.Structure.Adapter;
using ProjetDLL.DesignPatterns.Structure.Proxy;
using ProjetDLL.Genericite;
using ProjetDLL.Reflexion;
using ProjetDLL.SOLID.DependencyInjection.Good;
using ProjetDLL.SOLID.LiskovSubstitution.Bad;
using ProjetDLL.TypeDynamic;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static ProjetDLL.Delegates.Calcul;
using Directeur = ProjetDLL.DesignPatterns.Comportement.ChainOfResponsability.Directeur;
using Rectangle = ProjetDLL.DesignPatterns.Creation.Factory.Rectangle;

namespace ProjetConsole
{
    class Program
    {
        //Ressource partagée
         static int total = 0;

        // Verrou
        static object verrou = new object();

        static void Main(string[] args)
        {
            #region "Type Dynamic"

            //.net 4.5 introduit  un nouveau type de données - Type Dynamic
            //Né vérifie pas le type des variables à la compilation - la verification se fait à l'exécution
            //Pas besoin de faire des conversions - CAST.....

            dynamic myDynamic = 100;
            Console.WriteLine($"Valeur = {myDynamic} - Type: {myDynamic.GetType()}"); //int32

            myDynamic = "chaine";
            Console.WriteLine($"Valeur = {myDynamic} - Type: {myDynamic.GetType()}"); //string

            //Appel de la méthode Dynamic
            Console.WriteLine(ClasseDynamic.Additionner(10, 30)); //somme - 30

            Console.WriteLine(ClasseDynamic.Additionner("chaine1", "chaine2")); //Concaténation de chaine


            #endregion

            #region "Généricité"

            Console.WriteLine("***********************GENERICITE********************");
            /*
             *Généricité: nous permet de définir des classes et des méthodes génériques, identiques sur le plan algorthmique mais différents 
             *sur la base des types de données 
             * Intérêtes:
             * - réutilisation du code
             * - Pas besoin de faire de CAST: monis de ressources consommées
             * - Moins d'erreurs à l'exécution 
             */

            //Classe Générique
            MyClassGeneric<int> classGen = new MyClassGeneric<int>();
            classGen.A = 10;
            classGen.B = 20;
            classGen.Swap();
            Console.WriteLine($"A = {classGen.A} - B = {classGen.B}");

            int x = classGen.A; //Pas besoin de faire un CAST

            MyClassGeneric<string> classGen2 = new MyClassGeneric<string>();
            classGen2.A = "chaine1";
            classGen2.B = "chaine2";
            classGen2.Swap();
            Console.WriteLine($"A = {classGen2.A} - B= {classGen2.B}");

            //Utilisation de la classeGen2

            MyClassGen2 gen2 = new MyClassGen2();
            gen2.A = 10;

            int y = (int)gen2.A; //CAST est obligatoire

            //Appel de la méthode Generique
            Product p = new Product() { Description = "PC DELL", Price = 1500 };
            string result = JsonTool.ToJson<Product>(p);
            Console.WriteLine(result);

            #endregion

            #region "Reflexion - Introspection"

            Console.WriteLine("*****************REFLEXION - INTROSPECTION***************");
            /*
             * Mécanisme qui permet de découvrir des types (classes) et d'invoquer leurs membres à l'exécution
             * - Utilisation la classe Type pour récupérer le type de la classe en question
             * - GetFields(): pour récupérer les champs privés
             * - GetProperties() : pour récupérer les propriétés publiques
             * - GetMethods(): pour récupérer les méthodes de la classe
             * 
             */

            //Ex: lister les méthodes de la classe string

            //1-Récupérer le type de la classe string
            Type stringType = typeof(string);
            MethodInfo[] methods = stringType.GetMethods();
            Console.WriteLine("Méthodes de classe string:");

            foreach (var item in methods)
            {
                Console.WriteLine(item.Name);
            }

            //Lister les propriétés de la classe Employe via la reflexion
            Type empType = typeof(Employe);

            PropertyInfo[] props = empType.GetProperties();
            Console.WriteLine("Props de la classe Employe:");
            foreach (var pro in props)
            {
                Console.WriteLine(pro.Name);
            }

            //Lister les méthodes de la classe Employe

            var empMethods = empType.GetMethods();
            Console.WriteLine("Méthodes de la classe Employe:");

            foreach (var meth in empMethods)
            {
                Console.WriteLine(meth.Name);
            }

            //Appeler la méthode Afficher de la classe Employe - méthode d'instance
            Console.WriteLine("Appel de la méthode Afficher:");
            var methAfficher = empType.GetMethod("Afficher");

            //Instancier la classe Emplope dynamiquement
            var employe = Activator.CreateInstance(empType, null); //Appel du constructeur par defaut de la classe Employe

            if (!methAfficher.IsStatic)
            {
                Console.WriteLine("Non static......");
                if (methAfficher.IsPublic)
                {
                    Console.WriteLine("public.....");
                    methAfficher.Invoke(employe, null);
                }
            }

            var employe2 = Activator.CreateInstance(empType, "Dawan", "Paris");

            Console.WriteLine("Nouvel appel de la méthode Afficher:");
            methAfficher.Invoke(employe2, null);

            //Test de ToCsv
            List<Product> products = new List<Product>();
            products.Add(new Product { Description = "PC Dell", Price = 1500 });
            products.Add(new Product { Description = "Ecran HP", Price = 120 });
            CsvTool.ToCsv<Product>(products, "c:\\monRep\\products.csv");

            var prodCSV = CsvTool.FromCsv<Product>("c:\\monRep\\products.csv");
            foreach (var prod in prodCSV)
            {
                Console.WriteLine(prod);
            }

            #endregion

            #region "Delegate"

            Console.WriteLine("*****************DELEGATE*****************");
            /*
             * Delegate: un objet(une variable) qui pointe vers une méthode qui respecte une certaine signature
             * Intérêt:
             * Rendre les application facile à etendre
             * 
             */

            Calcul.Somme(10, 15);
            Calcul.Soustraction(10, 15);
            Operation op = Multiplication;
            Console.WriteLine(op(10, 15)); //150

            Operation division = (p1, p2) => p1 / p2;

            //Delegate MultiCast
            op += Calcul.Somme;

            Console.WriteLine("Appel du delegate MultiCast - qui pointe vers 2 méthodes:");
            op.Invoke(10, 5);

            op -= Multiplication;
            Console.WriteLine("Rappel du delegate Multicast après suppression de la multiplication:");
            op.Invoke(25, 30);

            //.net nous propose des delegate qu'on peut utiliser
            /*
             * Func: méthode qui renvoie une valeur
             * Action: méthode sans type de retour
             * Predicate: métodes qui renvoient un Boolean
             * 
             */
            Func<int, int, int> multipl = Multiplication;
            Func<int, int, int> Division = (a, b) => a / b;

            //Méthode qui prend en param un Product et qui affiche son prix
            Action<Product> AfficherPrix = (prod) => Console.WriteLine(prod.Price);

            //Méthode qui vérifie si le prix d'un produit est supérieur à 100
            Predicate<Product> PrixSup100 = (prod) => prod.Price > 100;

            Console.WriteLine("Utilisation des delegate du .net:");

            AfficherPrix(new Product { Price = 4500 });
            Console.WriteLine(  PrixSup100(new Product { Price = 99 }));

            //Méthode qui affiche parcours une liste de produit
            Action<List<Product>> AfficherListe = (lst) =>
                        {
                            foreach (var item in lst)
                            {
                                Console.WriteLine(item);
                            }
                        };
            AfficherListe(products);

            Console.WriteLine("Après moficiation de la liste des prosuits:");

            Calcul.GetAll(products, (lst) => 
            {
                lst.Add(new Product { Description = "clavier", Price = 80 });
                foreach (var item in lst)
                {
                    item.Price = item.Price - 10;
                }
                return lst;
            
            });

            AfficherListe(products);

            //Supprimer tous les produits dont le prix < 500 - Mettre la description en majuscule
            Calcul.GetAll(products, lst =>
            {
                //PC - Ecran - Clavier

                for (int i = lst.Count - 1; i >=0 ; i--)
                {
                    if (lst[i].Price < 500)
                    {
                        lst.Remove(lst[i]);
                    }
                }

                foreach (var pr in lst)
                {
                    pr.Description = p.Description.ToUpper();
                }

                return lst;
            });

            Console.WriteLine("Contenu de la liste après suppression + Majuscule:");
            AfficherListe(products);

            #endregion

            #region "Méthodes Anonymes - Expression Lambda"

            Console.WriteLine("**************EXPRESSION LAMBDA*************");
            /*
             * Expression Lambda: méthode anonyme: une autre syntaxe qui nous permte de définir des méthodes
             * (params) => bloc instructions;
             * 
             */
            List<Product> prods = new List<Product>();
            prods.Add(new Product { Description = "PC Dell", Price = 1500 });
            prods.Add(new Product { Description = "Ecran HP", Price = 110 });
            prods.Add(new Product { Description = "Clavier", Price = 40 });

            prods.Find(pr => pr.Description.Contains("c"));
            prods.ForEach(pr => Console.WriteLine(pr));

            

            //Tous les produits dont le prix est compris entre 100 et 2000
            prods.FindAll(pr => pr.Price > 100 && pr.Price < 2000).ForEach(pr => Console.WriteLine(pr));

            //Méthode d'extension
            string chaine = "test";
            Console.WriteLine("****************METHODE D'EXTENSION**************");
            //chaine = MyTool.ChangerPremierChar(chaine);
            //Console.WriteLine(  chaine);

            Console.WriteLine(chaine.ChangerPremierChar());





            #endregion

            #region "Processus"

            Console.WriteLine("**************PROCESS******************");
            //Process: un programme en cours d'exécution
            //Classe Proccess fournit par .net qui nous permet de récupérer des infos sur les programmes en cours d'exécution.
            //On peut aussi exécuter des application externes à notre application

            var processes = Process.GetProcessesByName("chrome");

            //octet / kilo octet / Mega / Giga
            double mega = 1024 * 1024;
            double giga = 1024 * 1024 * 1024;

            foreach (var proc in processes)
            {
                Console.WriteLine(proc.WorkingSet64 / mega);
            }

            Console.WriteLine("Mémoire utilisée par le projet console:");
            Console.WriteLine(Process.GetCurrentProcess().WorkingSet64 / mega);

            #endregion

            #region "Thread"

            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine("***************THREAD*******************");
            //Thread: une tâche à exécuetr encapsulée dans un process
            //Chaque Process (chaque application) possède un Thread qui lui associé (Thread Pricipal) - Une application mono thread qui ne peut exécutée qu'une
            //tâche à la fois
            //Les threads nous permettent d'isoler les tâches bloquantes dans des Threads - 
            //Intérêts: mettre en place des applicatiosn multi tâches - responsives

            //Simuation d'une tâche qui dure 5 secondes
            //Thread.Sleep(5000);

            Thread t1 = new Thread(() => 
            {
                Console.WriteLine("Tâche1.........");
                Thread.Sleep(10000); //simulation d'une tâche qui dure 10 secondes

            });

            Thread t2 = new Thread(() => 
            {
                Console.WriteLine("Tâche2.......");
            });

            t1.Start();
            t1.Join(3000); //Join mets en attente le Thread principal
            t2.Start();
            t2.Join();

            //Tâche principale doit attendre la fin des 2 tâches - t1 et t2

            Console.WriteLine("tâche principale..........");

            if (t1.IsAlive)
            {
                Console.WriteLine("t1 est en cours d'exécution.....");
            }

            //Accés à une ressource partagée: gestion de l'accés conccurrentiel à une ressource

            Console.WriteLine("Accés à une ressource partagée:");
            Thread th1 = new Thread(AddMillion);
            Thread th2 = new Thread(AddMillion);
            Thread th3 = new Thread(AddMillion);

            th1.Start();
            th2.Start();
            th3.Start();

            th1.Join();
            th2.Join();
            th3.Join();

            Console.WriteLine("Total = "+total);

            Console.WriteLine("Sur un PC avec 1 seul Processeur:");

            Stopwatch watch = Stopwatch.StartNew();
            Somme1();
            Somme2();
            watch.Stop();
            Console.WriteLine("Temps d'exécution avec 1 Proc: "+watch.ElapsedMilliseconds+" millisecondes");

            Console.WriteLine("Sur un PC avec 2 Processeurs:");

            watch = Stopwatch.StartNew();
            Thread tache1 = new Thread(Somme1);
            Thread tache2 = new Thread(Somme2);

            tache1.Start();
            tache2.Start();

            tache1.Join();
            tache2.Join(); //Join suspends le thread principal

            watch.Stop();
            Console.WriteLine("Thread: " + Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine("Temps d'exécution avec 2 Proc: " + watch.ElapsedMilliseconds + " millisecondes");

            //Multi threading: 
            //1- Mise en place d'applications multi tâches - applications responsives
            //2- Gain important en terme de temps d'exécution



            #endregion

            #region "Approche Asynchrone"

            Console.WriteLine("******************APPROCHE ASYNCHRONE**************");
            /*
             * Un programme par defaut s'exécute de manière synchrone:
             * - instruction1;
             * - methode();
             * - instruction2; - doit attendre la fin de la methode pour s'executer
             * 
             * 
             * Un programme Asynchrone:
             * - instruction1;
             * - async Task<string> methode(); - Async demande au compilateur d'isoler cette méthode dans un Thread
             * - instruction2; ne doit pas attendre la fin de la methode pour s'executer
             * - await instruction3; dépend du résultat de la méthode() - doit attendre la fin de l'exécution de la méthode - d'où le mot clé await
             * 
             * L'approche asynchrone utilise le mutli threading pour executer des tâches en parallèl
             * Une méthode asychrone est tâche Task: si la méthode renvoie un résultat Task<TypeRetour>
             * 
             * 
             */


            #endregion

            #region "Rappels Concepts Objets"

            Console.WriteLine("***************CONCEPTS OBJET****************");
            Console.ForegroundColor = ConsoleColor.Yellow;

            Screen sc = new Screen();
            Screen sc1 = new Screen();
            Screen sc2 = new Screen();

            Console.WriteLine("Nombre Srceen: "+Screen.NBScreens); //3

            sc1 = null; //Passage du Garbage Collector - Appel du Destructeur de la Classe Screen

            //Forcer le passage Garbage Collector
            GC.Collect(); //cet appel explicite ne garantit pas le passage immédiat du GC
       
            Console.WriteLine("Nombre Srceen: " + Screen.NBScreens);

            //Encapsulation
            //Rectangle rec = new Rectangle(50,40);
            //rec.Redim(20, 15);

            //Polymorphisme
            //Voir ProjetDLL - ConceptsObjets - Polymorphisme

            //Association - Composition - Agrégation d'objets

            //Quizz
            Console.WriteLine("***************TEST QUIZZ******************");
            //QuizTest quizTest = new QuizTest(DateTime.Now, QuizRepository.GenerateQuizz(), new Utilisateur("dawan", "mmahrane@dawan.fr"), 0);

            ////Pour chaque question

            //foreach (Question question in quizTest.Quizz.Questions)
            //{
            //    //Afficher l'énoncé
            //    Console.WriteLine(question.QstText);

            //    int i = 1;

            //    //Afficher les réponses de la question

            //    foreach (Reponse reponse in question.Reponses)
            //    {
            //        Console.WriteLine($"{i} - {reponse.RepText}");
            //        i++;
            //    }

            //    //Demander à l'utilisateur son choix

            //    do
            //    {
            //        try
            //        {
            //            Console.WriteLine("Votre choix:");
            //            string choiceStr = Console.ReadLine();
            //            quizTest.CheckReponse(question, choiceStr);
            //            break;
            //        }
            //        catch (Exception ex)
            //        {

            //            Console.WriteLine(ex.Message);
            //        }


            //    } while (true);
            //}

            ////Afficher le score
            //Console.WriteLine("Votre score est: "+quizTest.Score);

            //quizTest.SendResult();
            //Console.WriteLine("Résultat envoyé par email");

            //Tout dev peut écrire code qu'une machine - Un bon dev c'est celui qui peut écrire un code qu'un ^étre humain peut comprendre


            #endregion

            #region "Loi DEMETER"

            Console.WriteLine("*******************LOI DEMETER*************");
            /*
             * Une classe peut utiliser d'autres classes soit par association, soit par passage de paramétres dans ses méthodes
             * - Classe A utilise Classe B
             * - Classe B utilise Classe C
             * - Classe A utilise Classe C
             * 
             * Loi Demeter:
             * Chaque classe doit avoir une connaissance limitée des autres classes.
             * 
             * En pratique:
             * une classe ne doit parler qu'à ses classes amies
             * Une méthode d'une classe doit utiliser:
             * - ses arguments
             * - des objets crées dans la méthode elle même
             * - des propriétés et champs de la classe
             * - la classe elle même
             * 
             * Voir ProjetDLL - Demeter
             */

            #endregion

            #region "Tell D'ont ASK"

            Console.WriteLine("****************TELL DONT ASK************");
            //Dites, ne demandez pas. Dites à vos objets ce qu'ils doivent faire, ne leur posez pas des questions sur leur état.
            //Voir ProjetDLL - TellDontAsk

            #endregion

            #region "Principes SOLID"

            Console.WriteLine("*********************SOLID***************");
            /*
             * SOLID est l'acronyme de 5 principes de la conception objet:
             * S: Single Of Responsability
             * O: Open/Close
             * L: Liskov Substitution
             * I: Interface Segregation
             * D: Dependency Injection - Dependency Inversion
             * 
             * se sont de bonnes pratiques à appliquer dans la conception objets.
             * 
             * Intérêts:
             * permettent d'améliorer la cohésion, de diminuer le couplage et de favoriser l'encapsulation d'un programme objet.
             * 
             * -Cohésion:
             * un module (une classe) est cohésif, lorsqu'au niveau de l'abstraction il ne fait qu'une seule et unique tâche précise.
             * 
             * -Couplage:
             * Le couplage est une métrique qui mesure l'interconnexion des modules ( ensemble de classes).
             * 2 modules (2 classes) sont dits couplés si une modification d'un de ces modules demande une modification dans l'autre.
             * 
             * -Encapsulation:
             * Une classe (un objet) devrait masquer au maximum sa structure interne.
             * 
             */
            /*
             * **********************SINGLE OF RESPONSABILITY
             * Une classe données ne doit avoir qu'une seule responsabilité, par conséquence elle ne doit avoir qu'une seule raison de changer.
             * Avantages:
             * - Code plus lisible - plus facile à maintenir
             * Voir ProjetDLL - SOLID - SingleOfResponsability
             * 
             * *********************OPEN/CLOSE
             * Une classe doit être fermée à la modification et ouverte à l'extension
             * But:
             * proposer aux utilisateurs des objets (classes) auxquels ils peuvent ajouter de nouveaux comportements sans en modifier la structure interne 
             * de l'objet (classe)
             * 
             * Voir ProjetDLL - SOLID - OpenClose
             * 
             * ******************Liskov Substitution
             * Les sous types doivent être substituables à leur type de base
             * Remplacer une classe parent par une classe enfant: doit garantir que la classe enfant se comporte comme la classe parent.
             * Solution: les classes enfants doivent garder l'implémentation des méthodes de la classe parente.
             * 
             * 
             */
            //Vehicule vehicule = new Vehicule();
            //vehicule.demarrer(); //Véhicule démarré...

            //Voiture voiture = new Voiture();
            //voiture.demarrer(); //Voiture démarrée..... --- Liskov Substitution n'est pas respecté --- 

            /*
             * *************Interface Segregation - Séparation d'interfaces
             * Plus une interface est complèxe plus elle est susceptible d'évoluer avec temps.
             * Chaque MAJ d'une interface va entrainer nune modification de toutes les classes clientes
             * Une classe A qui utilise la nouvelle fonctionnalité de A - la classe B qui n'est concernée par cette fonctionnalité, doit imlementer la fonction A
             * 
             * Solution: appliquer le principe de Single of Responsabiility aux interfaces - Découper l'interface complèxe en petite interfaces orientée métier
             * 
             * ******************DEPENDENCY INJECTION
             * Les couches supérieures d'une application doivent rester indépendantes des couches inférieures
             * Solution: les couches supérieures doivent dépendre d'interfaces
             */

            //Injection par constructeur
            //UserService service = new UserService(new UserRepositoryFichier());
            //service.TraiterUser(1);

            ////Injection par paramétres de la méthode
            //service.TraiterUser(1, new UserRepository());
            //service.TraiterUser(2, new UserRepositoryFichier());

            ////Injection par mutateur (setteur)
            //service.repository = new UserRepository();
            //service.repository = new UserRepositoryFichier();

            //Voir ProjetDLL - SOLID - DependencyInjection

            #endregion

            #region "Designs Patterns"

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("********************DESIGN PATTERN****************");
            /*
             * Design Pattern: solution classique(standard) mise en place par la communauté objet pour répondre à des problèmes réccurrents de la conception objet.
             * GOF - Gang Of Four
             * 
             * Patterns de création:
             * Singleton - Factory - Builder - Prototype - Abstract Factory
             * 
             * Patterns de comportement:
             * Composite - Decorator - Iterator - Memento - Observer - Chain Of Responsability - State - Strategy
             * 
             * Patterns de structure:
             * Adapter - Mediator - Command -Proxy - Visitor
             * 
             * 
             * 
             */
            //****************************************PATTERNS DE CREATION***********************
            Console.WriteLine("****************SINGLETON**********************");
            //Problème: dans toute l'application, on doit garantir à tout moment qu'on ne peut avoir qu'une seule te unique instance 
            //d'une classe donnée
            Directeurs dir1 = Directeurs.Instance;
            dir1.Name = "dir1";

            Directeurs dir2 = Directeurs.Instance;
            dir2.Name = "dir2";

            Console.WriteLine("Dir1: "+dir1.Name);
            Console.WriteLine("Dir2: "+dir2.Name);

            Console.WriteLine("*****************FACTORY*************************");
            //Objectif: avoir qu'une seule et unique classe qui gère la construction d'objets sans précicer leur type

            var rect = ShapeFactory.CreateShape<Rectangle>(typeof(Rectangle), null);
            var circle = ShapeFactory.CreateShape<Circle>(typeof(Circle), null);
            var triangle = ShapeFactory.CreateShape<Triangle>(typeof(Triangle), null);

            Console.WriteLine("**************PROTOTYPE**********************");
            //Problème: créer de nouveaux objets à partir d'objets existants sans rendre le code dépendant de leur classe
            //Avoir une copie d'objet sans faire: obj2.A = obj1.A

            Article art1 = new Article { Description = "PC Dell", Price = 1500 };
            //Article art2 = new Article();
            //art2.Description = art1.Description;
            //art2.Price = art1.Price;
            //art2 = art1;

            Article art2 = (Article)art1.Clone();
            art1.Description = "Ecran HP";

            Console.WriteLine("Article1: "+art1.Description); //Ecran HP
            Console.WriteLine("Article2: "+art2.Description); //PC Dell

            Console.WriteLine("***************CLONAGE TYPE COMPLEXE****************");
            //Clonage d'un type complèxe
            LineArticle line1 = new LineArticle { Article = art1, Qty = 10 };
            LineArticle line2 = (LineArticle)line1.Clone();

            //line1.Article = art2;

            line1.Article.Description = "Table";
            line1.Qty = 20;

            Console.WriteLine("Line1: "+line1);
            Console.WriteLine("Line2: "+line2);

            Console.WriteLine("**********************BUILDER******************");
            //Concerne les classes objets qui peuvent contenir plusieurs propriétés à initialiser
            //Propose une classe qui gère la contruction d'objet et qui permet de remplacer les différents constructeur de la classe à gérer

            BankAccount ac1 = new BankAccountBuilder()
                .WithNumber(1589)
                .WithLoan(10000, 2.5f)
                .AccountIsLoanInsured(true)
                .WithNameAndPassword("nom", "password")
                .WithType(AccountType.COURANT)
                .Build();

            BankAccount ac2 = new BankAccountBuilder()
                .WithNumber(1489)
                .WithNameAndPassword("name", "password")
                .WithType(AccountType.EPARGNE)
                .Build();

            ac2.accountNumber = 2500;


            //***********************************PATTERNS DE COMPORTEMENT*********************
            Console.WriteLine("**************MEMENTO*******************");

            //Sauvegarde et restauration: revenir à l'état précedent d'un objet
            //Ex: editeur de texte
            /*
             * a
             * b
             * c
             * 
             */
            Editeur editeur = new Editeur();
            var history = new History();
            editeur.Content = "a";
            history.Push(editeur.CreateState());
            editeur.Content = "b";
            history.Push(editeur.CreateState());
            editeur.Content = "c";

            Console.WriteLine("Etat actuel de l'editeur: "+editeur.Content); //c
            editeur.Restore(history.Pop());

            Console.WriteLine("Restore1: "+editeur.Content); //b

            editeur.Restore(history.Pop());
            Console.WriteLine("Restore2: "+editeur.Content); //a

            Console.WriteLine("*************************OBSERVER***************");
            //Objectif: mise en place d'un système de notification - mécanisme de souscription pour recevoir des notifications au sujet
            //d'un évenement qui vient de se produire

            ProductItem prod2 = new ProductItem { Description = "PC Dell", Price = 1500 };
            prod2.Attach(new Customer("dawan", "mmahrane@dawan.fr"));
            prod2.Attach(new Customer("jehann", "messaoudmuhammad9@gmail.com"));
           // prod2.Price = 950; //cette modif déclenche un envoi de mail à tous les observer

            Console.WriteLine("*******************CHAIN OF RESPONSABILITY********************");
            //:Permet de faire circuler des demandes dans une chaine de Handler. Lorsqu'un Handler reçoit une demande
            //il peut soit traiter la demande, soit l'envoyer au handler suivant
            //Les points communs entre les différents handler: possèdent tous un supérieur - et peuvent tous traiter la demande


            StaffMember prof = new Teacher("prof", new ResponsablePedago("pedago", new Directeur("directeur", null)));

            Console.WriteLine("****REQ1********");
            prof.HandleComplaint(new ComplaintRequest(145, 1, "req1", ComplaintRequest.ComplaintState.OPENED));

            Console.WriteLine("****REQ2********");
            prof.HandleComplaint(new ComplaintRequest(520, 2, "req2", ComplaintRequest.ComplaintState.OPENED));

            Console.WriteLine("****REQ3********");
            prof.HandleComplaint(new ComplaintRequest(965, 3, "req3", ComplaintRequest.ComplaintState.OPENED));

            //**************************PATTERNS DE STRUCTURE
            Console.WriteLine("****************PROXY****************");

            //Objectif: permet d'utiliser un substitut pour un objet. Donne le contrôle sur l'objet original pour nous permettre
            //d'effectuer des manipulations dessus avant ou après que lui la demande lui parvienne
            //L'objet original passe par proxy
            //Ex: envoi d'un message

            var messageInitial = new UserMessage("bonjour");
            var messageFinal = new MessageProxy(messageInitial);
            Console.WriteLine("Message final: "+messageFinal.GetContent());

            var finalMessage = new MessageProxy(new UserMessage("test"));

            Console.WriteLine("*************ADAPTER****************");

            //permet de faire collaborer des objets ayant des interfaces normalement incompatibles
            //Conversion d'interfaces 
            //Ex: interface qui renvoie du contenu xml - Fournir une interface pour adapter le contenu en json

            var adapter = new JsonAdapter(new ContactRepository());
            string contenuJson = adapter.FindJsonContacts("contacts.xml");
            Console.WriteLine(contenuJson);

            #endregion




            //Maintenir la console active
            Console.Read();
        }

        public static int Multiplication(int x, int y)
        {
            Console.WriteLine("Multiplication: "+(x*y));
            return x * y;
        }

        //public static int Division(int x, int y)
        //{
        //    return x / y;
        //}

        //public static void AfficherPrix(Product p)
        //{
        //    Console.WriteLine(p.Price);
        //}

        public static void AddMillion()
        {
            for (int i = 0; i < 100000; i++)
            {
                //Vérrouillage de la ressource
                lock (verrou)
                {
                    total++;
                }
 
            }
        }

        public void Afficher()
        {

        }

        public static void Somme1()
        {
            int sum = 0;
            for (int i = 0; i < 50000000; i++)
            {
                sum += i;
            }
            Console.WriteLine("Thread: "+Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine("Sum1 = "+sum);
        }

        public static void Somme2()
        {
            int sum = 0;
            for (int i = 0; i < 50000000; i++)
            {
                sum += i;
            }
            Console.WriteLine("Thread: " + Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine("Sum2 = " + sum);
        }
    }
}
