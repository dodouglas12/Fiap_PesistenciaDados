INSERT INTO HEROIS
VALUES (1, 'Herói 1', '2000-01-25', 'Voar');

INSERT INTO HEROIS
VALUES (2, 'Herói 2', '1994-03-12', 'Super Força');

INSERT INTO HEROIS
VALUES (3, 'Herói 3', '2005-09-03', 'Laser nos olhos');

UPDATE HEROIS SET
	nome = 'Super Homem'
WHERE codigo = 2;

DELETE FROM HEROIS
WHERE codigo = 1;

SELECT * FROM HEROIS;