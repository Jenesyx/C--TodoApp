INSERT INTO Mitarbeiter(name, admin)
VALUES('ali', 1),('marcel', 0);
INSERT INTO Projekte(name, Beschreibung, Mitarbeiter_ID)
VALUES('Project1', 'This is a test', 1),('Project2', 'This is a test', 2);
INSERT INTO Todos(name, Beschreibung, status, Projekt_ID)
VALUES('Todo1', 'This is a test', 0, 1),('Todo2', 'This is a test', 1, 2);
INSERT INTO Mitarbeiter_Todo(Mitarbeiter_ID, Todo_ID)
VALUES(1,1),(2,2);