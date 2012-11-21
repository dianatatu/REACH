Membrii echipei:
 - Tatu Diana - 334CA - diana.tatu@gmail.com
 - Daniela Vatamanu - 334CA - daniela.vatamanu@gmail.com
 - Bogdan Purcareata - 331CA - bogdan.purcareata@gmail.com
 - Filip Buruiana - 334CA - filip.buruiana@gmail.com
 - Valentin Dobrota - 334CA - valydo@gmail.com
 
REACH - Realtime Enlightenment and Community Help

REACH este un loc de intalnire pasionatilor de tehnologie, care pot cere ajutor in timp real despre probleme tehnice si pot discuta pe teme variate. Gruparea tematica ofera utilizatorului acces la ultimele discutii, legaturi si alte materiale adaugate de membrii comunitatii.

== Facilitati ==
= Discutii =
Discutie = conversatie intrebare-raspuns (cu replici)
Sistem realtime de postare si raspundere intrebari (de discutii) - Instant messaging
Intrebarile au taguri si optional, nivele de dificultate. Ex: PHP, Apache [mid-level]
Discutiile sunt publicate si pe server-pagina web (pot fi astfel indexate de motoarele de cautare) daca cel care a pus intrebarea si cel care a postat intrebarea sunt de acord.
La postarea unei intrebari snippeturile de cod vor avea syntax highlight si alte optiuni.
La intrebari oferim si documentatie in cadrul programului (documentatia unei functii dintr-un anumit limbaj de exemplu)
La intrebari sa iti ofere si niste discutii mai vechi pe aceeasi tema care sa fie cat mai relevante. Se evita astfel duplicarea de intrebari.
Intrebarile sunt intr-un pool tematic si userii care vor sa raspunda iau din poolul de intrebari fara raspuns
= Useri: =
Selectie useri: chestionar generic pentru admitere
Userii pot selecta la ce taguri sa primeasca intrebari [ + nivel dificultate]
Lista de contacte
Instant Messaging separat de sistemul intrebare-raspuns
Profil user
Sistem rating useri (rating la raspunsuri, nr ore online)
= Lounge tematic:  =
un chat unde discuta toti cei interesati
Shelf: documentatie, video docs - adaugate de utilizatori
Noutati: ultimele discutii pe acea temaLa intrebari se poate raspunde si offline
= Alte idei de componente: = 
Interfatare IRC: utilizatorii pot discuta si pe canale IRC, le sugeram anumite canale relevante
Intefatare IRC inversa: utilizatorii IRC pot raspunde si intreba utlizatorii REACH.

	
======= Arhitectura generala =======

Proiectul este compus din doua entitati principale: partea de client si partea de server. La un moment dat, pot exista mai multi clienti activi (mai multe instante ale aplicatiei pornite de utilizatori diferiti) si un singur server care gestioneaza interactiunea dintre acesti clienti. Orice comunicatie punct la punct între clienti este intermediata de catre server.

1.1 Arhitectura clientului

Partea de client este reprezentata de aplicatia folosita de un utilizator. Arhitectura clientului este construita astfel încât sa separe logica si partea de manipulare a datelor de partea de afisare. Din acest punct de vedere, sunt folosite principii de design existente în unele modele consacrate, precum Model-View-Controller (MVC). De asemenea, se separa logica aplicatiei de partea de comunicare cu server-ul prin încapsularea metodelor folosite pentru comunicare într-un serviciu.

Astfel, la nivelul clientului se regasesc urmatoarele entitati:
¦	View: entitatea ce gestioneaza afi?area datelor dintr-un Model ?i care este reponsabila de interac?iunea cu utilizatorul.
¦	Controller: entitatea ce specifica logica de manipulare a datelor, ?i care comunica cu serviciul pentru rezolvarea cererilor ce trebuiesc tratate de catre server.
¦	Model: entitatea în care sunt salvate datele, identificând starea aplica?iei.
¦	Service: entitatea ce comunica direct cu server-ul pentru rezolvarea cererilor efectuate de un Controller.
¦	Context: entitatea ce re?ine atât asocierile dintre Controller-e ?i Modele, cât ?i Modelele singleton, relevante la nivelul întregii aplica?ii, care nu au un View ?i un Controller asociat (cum este de exemplu cazul modelului ce re?ine utilizatorul curent conectat).

Asocierea dintre instantele pentru View, Model si Controller este 1:1:1. Asadar, fiecare instanta a unui View va avea asociata o instanta a unui Controller, iar fiecare instanta a unui Controller va avea asociata o instanta a unui Model.

La fiecare moment de timp pot exista mai multe entitati de tipul View, Model sau Controller. De asemenea, pot exista mai multe instante ale aceluiasi View, si implicit mai multe instante ale aceluiasi Controller sau Model.

Entitatatile Serviciu si Context ilustreaza modelul Singleton, existând o singura instanta de acest tip pe tot ciclul de viata al aplicatiei.


1.1.1 Entitatea View

View-ul este entitatea ce gestioneaza afi?area datelor dintr-un Model si care este responsabila de interactiunea cu utilizatorul.
View-ul va reactiona atât la evenimentele generate din interfata grafica (apasarea unui buton, a unei taste, etc), cât si la evenimentele generate de Controller, folosite pentru a notifica View-ul de schimbarea modelului. Fiecare astfel de eveniment va avea asociata o rutina de tratare, denumita handler.
Evenimentele generate din interfata grafica se vor numi evenimente interne. Un handler pentru un astfel de eveniment va apela o metoda din Controller-ul asociat View-ului, în functie de actiunea care trebuie luata.
Evenimentele generate de Controller se vor numi evenimente externe, si sunt folosite, dupa cum s-a precizat si mai sus, pentru a înstiinta View-ul de actualizarea modelului. View-ul nu va avea acces direct la model, ci îl va primi ca parametru în handler-ul de tratare a evenimentului. View-ul trebuie sa apeleze doar metode constante (care nu modifica modelul) pentru a ob?ine datele de care are nevoie pentru a actualiza interfata.


1.1.2 Entitatea Controller

Aceasta entitate este cea care încapsuleaza logica de manipulare a datelor. De asemenea, entitatea este responsabila de comunicarea cu serviciul pentru rezolvarea cererilor ce trebuiesc tratate de catre server.
În orice clasa ce reprezinta un Controller vor exista doua tipuri de metode:

¦	metode apelate de View, prin care se solicita actualizarea datelor pe baza actiunilor utilizatorului (apasarea unui buton, etc). Aceste metode se vor numi comenzi.
¦	metode apelate de Serviciu, care sunt chemate la primirea unui raspuns asincron de la server. Aceste metode se vor numi callback functions.

O comanda va trebui sa execute anumite operatii, care pot fi: 

¦	sincrone, în cazul în care datele trebuie modificate doar local. În acest caz, dupa terminarea executiei pasilor specifici si dupa actualizarea modelului,  Controller-ul va arunca un eveniment, care va fi prins de catre o rutina de tratare a unui eveniment extern în View.
¦	asincrone, în cazul în care cererea trebuie sa fie trimisa catre server. În acest caz, metoda trebuie sa formeze un obiect de tipul Message, pe care sa îl paseze apoi primitivei addMessage a entita?ii Service. Un mesaj contine tipul cererii si un obiect cu parametrii acesteia.


1.1.3 Entitatea Model

Entitatea Model este responsabila cu reprezentarea datelor. Ansamblul modelelor instantiate la un moment dat identifica starea în care se afla aplica?ia. Un model poate fi modificat doar de Controller-ul asociat. De asemenea, modelul va fi pasat unui View în rutinele de tratare a evenimentelor externe, generate de Controller.
Modelul poate declara atât câmpuri publice care pot fi modificate direct de catre Controller, cât si getteri si setteri.
Consistenta si integritatea datelor poate fi gestionata fie pe partea de Controller, fie pe partea de Model. Nu se specifica nicio restrictie în acest sens, iar alegerea apartine celui care implementeaza un anumit modul.


1.1.4 Entitatea Service

Aceasta entitate este responsabila de comunicatia cu server-ul. Cererile efectuate sunt rezolvate asincron. Entitatea va fi reprezentata printr-o singura instanta la nivelul întregii aplicatii, respectând modelul Singleton. Comunicarea efectiva cu server-ul se realizeaza folosind sockets: System.Net.Sockets.TcpClient. IP-ul si portul pe care se realizeaza conexiunea la server sunt hardcodate.
Serviciul va pune la dispozitia Controller-elor o primitiva care înregistreaza o noua cerere: addMessage, care va primi un mesaj ce trebuie trimis catre server. Un mesaj încapsuleaza atât tipul cererii cât si un obiect cu parametrii cererii. Cererile sunt puse într-o coada locala de cereri neprocesate.
Serviciul va rula un thread care la intervale de timp de ordinul zecilor de milisecunde va trimite server-ului toate cererile care se afla în coada locala. Dupa aceasta, coada este golita.
Un alt thread al serviciului va fi responsabil de gestiunea mesajelor primite. Se disting urmatoarele cazuri:

¦	mesajul primit a venit ca raspuns la o cerere anterioara efectuata de client.
¦	mesajul a venit ca rezultat al unei actiuni efectuate de alt client (de exemplu, alt utilizator porneste o noua discutie sau trimite o noua replica).

Ambele situatii sunt tratate identic. Trebuiesc identificate:

¦	o instanta a unui model ce trebuie actualizat;
¦	o functie de callback din Controller-ul asociat modelului ce trebuie apelata.
Pot exista mai multe modele care trebuiesc actualizate, si, implicit, mai multe functii de callback care trebuiesc apelate.

Pentru aceasta, serviciul va apela la primirea unui mesaj metoda statica FireCallback din Context, careia îi va pasa ca argument si mesajul receptionat de la server. Aceasta metoda va deveni responsabila cu identificarea si apelarea functiilor necesare.
Pot exista si situatii în care, pentru un mesaj primit, nu se identifica niciun model care trebuie modificat. În acest caz, contextul este responsabil sa aleaga un View pe care sa îl instantieze, pe baza tipului mesajului primit si a datelor din acesta. De exemplu, daca un utilizator A îi trimite un mesaj de tip conversatie (chat) unui utilizator B, iar utilizatorul B nu are fereastra conversatiei pornita, se va porni o noua fereastra. În acest moment, View-ul noul creat se va înregistra la un Controller, iar Controller-ul la un Model.


1.1.5 Entitatea Context

Entitatea Context va retine o mapare între toate modelele existente la un moment dat în sistem si toate Controller-ele. De asemenea, aceasta entitate va trebui sa implementeze metoda statica FireCallback, apelata de catre Service atunci când trebuie determinate functiile de callback ce trebuiesc apelate.
Contextul se va ocupa si de gestionarea unor modele speciale, care nu au un View si un Controller asociat, deoarece sunt relevante la nivelul întregii aplicatii (cum este de exemplu cazul modelului ce re?ine utilizatorul curent conectat). Aceste modele pot fi preluate de orice Controller direct din Context.


1.2 Arhitectura server-ului

1.2.1 Nucleul
Singleton
Acest modul asteapta conexiuni pe portul 4296. La primirea unei cereri de conexiuni porneste un ClientWorker pe un fir de executie nou.
Aici se retine o mapare între id-urile userilor si conexiunea cu acel user. Aceasta mapare este necesara pentru a stii pe ce canal sa trimita atât mesajele unicast, cât si cele broadcast.

1.2.2 ClientWorker
1 per conexiune cu client
Acest modul face busy waiting pe canalul deschis cu utilizatorul. Mesajul primit de la client este compus din lungimea payloadului si payloadul efectiv. Payloadul este un obiect de tip Message. Acest obiect si conexiunea este trimis Commander-ului.

1.2.3 Commander
Singleton
Commander primeste de la un ClientWorker un Message si conexiunea pe care s-a primit acest mesaj. In functie de tipul mesajului se fac anumite actiuni. Acest actiuni poti fi:
- una sau mai multe interogari la baza de date
- un mesaj unicast 
- un mesaj multicast
- un mesaj broadcast
Pentru trimiterea mesajelor se foloseste maparea din nucleu.
Pentru interogari la baza de date se folosesc obiectele din clasa *SqlConnecter

1.2.4 MySqlConnecter
Singleton
Acest obiect porneste la instantiere conexiunea cu baza de date. De asemenea ofera o interfata pentru a obtine un cititor de stream, dându-se un query:
public MySqlDataReader getReaderForQuery(String query)

1.2.5 Familia *SqlConnecter++
Singleton
* = User, Log, Question, UserVote, Friendship, Resource, Domain, ResourceVote, QuizItem, General
Aici se implementeaza toate tipurile de cereri catre baza de date. Separarea se face în functie de tipul de date ce trebuie returnate la Commander.
GeneralSqlConnecter implementeza cererile al caror tip de date de return nu se încadreaza în celalalte tipuri (e.g. Boolean).
O functie va primi parametrii necesari, nestandardizati, va construi stringul query, va obtine un Reader folosing MySqlConnecter si va citi din acest Reader obiectul necesar.

1.2.6 Biblioteca de serializare
Pentru comunicatie, atât serverul, cât si clientul folosesc o biblioteca de serializare/deserializare comuna.

1.2.8 Tipurile de mesaje
Clientul si serverul au acces la o lista de tipuri de mesaje. Tipurile de mesaje vor fi detaliate in cadrul sectiunii urmatoare.
