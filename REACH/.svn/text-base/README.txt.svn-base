
======= 1. STRUCTURA =======
Arhitectura pentru proiectul REACH este aproape finalizata. Structura este urmatoarea:
	* Core: interfete pentru entitatile principale. Fisierele din package nu vor fi modificate.
	* Base: implementari pentru interfetele din Core. Fisierele din package nu vor fi modificate.
	* Views: package care va contine view-urile pe care le cream noi.
	* Controllers: package care contine controller-ele pe care le cream noi.
	* Models: package care contine modelele pe care le cream noi.
	
======= 2. UPDATES =======
a) Ca element de noutate in arhitectura este modul in care sunt apelate "callback functions". Astfel, pentru fiecare callback trebuie definit un "TriggerRule" (o regula care, pe baza unui mesaj, decide daca callback-ul trebuie chemat sau nu). Toata logica se gaseste acum in Controller si nu mai trebuie modificat Context-ul. In constructor trebuie sa apelati RegisterTriggerRule:   		
	Context.RegisterTriggerRule(OnGetQuestion, OnGetQuestionRule);
Consultati exemplele de pe SVN.
	
b) Fiecare Controller este parametrizat cu un tip (tipul modelului pe care il gestioneaza).

c) Corect ar fi fost ca, clasa Service sa ofere o interfata publica controller-elor, si nu controller-ele sa formeze mesajele cu request-ul si doar sa le paseze la Service. Ca sa nu ne suprapunem peste fisierul Service si sa stam sa rezolvam diferente, am decis sa las gestiunea mesajelor in controller.

======== 3. TODOs ========
TODO @all: 
	* Putem incepe sa implementam view-urile, modelele si controller-ele dupa cum scrie in documentatie. Nu ne suprapunem in niciun fel, fiecare implementeaza verticala lui.

TODO @Vali:
	* Finalizeaza clasa Service, implementand TODO-urile din sursa. Momentan metodele de trimitere si receptionare sunt mocked.
	
TODO @Filip:
	* Finalizeaza clasa Context din Base, implementand gestiunea modelelor Singleton (gen LoggedInUser).

======= 4. EXEMPLE =======
SVN Update