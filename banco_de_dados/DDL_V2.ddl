--SQL Server

CREATE SEQUENCE objetivo_id_seq START WITH 1 INCREMENT BY 1;
CREATE TABLE objetivo (
    id_objetivo INT DEFAULT NEXT VALUE FOR objetivo_id_seq PRIMARY KEY,
    brasil VARCHAR(1000) NOT NULL,
    global VARCHAR(1000) NOT NULL
);

-------------------ODS--------------------

CREATE SEQUENCE ods_id_seq START WITH 1 INCREMENT BY 1;
CREATE TABLE ods (
    id_ods     INT DEFAULT NEXT VALUE FOR ods_id_seq PRIMARY KEY,
    codigo      VARCHAR(10) NOT NULL,
    id_objetivo INT NOT NULL,
    CONSTRAINT ods_objetivo_fk FOREIGN KEY (id_objetivo) REFERENCES objetivo (id_objetivo)
);


--------------------INDICADOR--------------------------
CREATE SEQUENCE indicador_id_seq START WITH 1 INCREMENT BY 1;
CREATE TABLE indicador (
    id_indicador INT DEFAULT NEXT VALUE FOR indicador_id_seq PRIMARY KEY,
    ano          INT NOT NULL,
    regiao       VARCHAR(100),
    codigo       VARCHAR(10) NOT NULL,
    consumo      DECIMAL(10, 2) NOT NULL,
    descricao    VARCHAR(500) NOT NULL,
    id_ods       INT NOT NULL,
    CONSTRAINT indicador_ods_fk FOREIGN KEY (id_ods) REFERENCES ods (id_ods)
);