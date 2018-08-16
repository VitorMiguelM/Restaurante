﻿DROP TABLE pratos;
DROP TABLE ingredientes;
DROP TABLE ingredientes_pratos;

CREATE TABLE pratos(
	id							INT IDENTITY(1,1) PRIMARY KEY,
	nome						VARCHAR(200) NOT NULL,
	modo_preparo				VARCHAR(2000) NOT NULL,
	propriedades_nutricionais	VARCHAR(500),
	preco						REAL NOT NULL,
	descricao					TEXT,
);

CREATE TABLE ingredientes(
	id		INT IDENTITY(1,1) PRIMARY KEY,
	nome	VARCHAR(500)
);

CREATE TABLE ingredientes_pratos(
	id				INT IDENTITY(1,1),
	id_prato		INT,
	id_ingrediente	INT,
	FOREIGN KEY (id_prato) REFERENCES pratos(id),
	FOREIGN KEY (id_ingrediente) REFERENCES ingredientes(id)
);

INSERT INTO pratos VALUES ('Bolo Simples', 'Bata as claras em neve e reserve. Misture as gemas, a margarina e o açúcar até obter uma massa homogênea. Acrescente o leite e a farinha de trigo aos poucos, sem parar de bater. Por último, adicione as claras em neve e o fermento. Despeje a massa em uma forma grande de furo central untada e enfarinhada. Asse em forno médio 180 °C, preaquecido, por aproximadamente 40 minutos ou ao furar o bolo com um garfo, este saia limpo', '', 28.90, '');

INSERT INTO ingredientes VALUES ('2 xícaras (chá) de açúcar, 3 xícaras (chá) de farinha de trigo, 4 colheres (sopa) de margarina, 3 ovos, 1 e 1/2 xícara (chá) de leite, 1 colher (sopa) bem cheia de fermento em pó');


SELECT * FROM pratos;
SELECT * FROM ingredientes;