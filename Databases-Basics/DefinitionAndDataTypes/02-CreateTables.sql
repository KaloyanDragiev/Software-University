CREATE TABLE Minions
(
Id INT NOT NULL,
Name VARCHAR(50) NOT NULL,
Age INT
)

CREATE TABLE TOWNS
(
Id INT NOT NULL,
Name VARCHAR(50) NOT NULL
)

ALTER TABLE TOWNS
ADD PRIMARY KEY (Id)

ALTER TABLE Minions
ADD PRIMARY KEY (Id)