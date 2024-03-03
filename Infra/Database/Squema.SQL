CREATE  DATABASE financas;

CREATE TABLE debit(
    
    id SERIAL PRIMARY KEY,
    value DECIMAL,
    description varchar(100),
    type varchar(10),
    date TIMESTAMP DEFAULT now()
    idUser VARCHAR(100),
    CONSTRAINT idUser FOREIGN KEY (idUser) REFERENCES users(id) ON DELETE CASCADE
);
CREATE TABLE credit (
    id SERIAL PRIMARY KEY,
    value DECIMAL,
    description VARCHAR(100),
    date TIMESTAMP DEFAULT NOW(),
    idUser VARCHAR(100),
    CONSTRAINT idUser FOREIGN KEY (idUser) REFERENCES users(id) ON DELETE CASCADE
);

Create Table users(
    id varchar(100) primary key,
    name varchar(100),
    email varchar(30) unique,
    date TIMESTAMP DEFAULT now()
);



