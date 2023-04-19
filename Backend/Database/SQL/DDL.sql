CREATE DATABASE services_manager;
\c services_manager;
CREATE TABLE client (
    id uuid NOT NULL,
    createdat TIMESTAMP NOT NULL,
    name VARCHAR NOT NULL,

    PRIMARY KEY (id)
);
CREATE TABLE collaborator (
    id uuid NOT NULL,
    createdat TIMESTAMP NOT NULL,
    name VARCHAR NOT NULL,

    PRIMARY KEY (id)
);
CREATE TABLE car (
    id uuid NOT NULL,
    createdat TIMESTAMP NOT NULL,
    ownerid uuid NOT NULL,
    model VARCHAR NOT NULL,
    year VARCHAR NOT NULL,    
    
    PRIMARY KEY (id),
    CONSTRAINT fk_owner FOREIGN KEY(ownerid) REFERENCES client(id)
);
CREATE TABLE part (
    id uuid NOT NULL,
    createdat TIMESTAMP NOT NULL,
    name VARCHAR NOT NULL,
    price decimal NOT NULL,

    PRIMARY KEY (id)
);
CREATE TABLE service (
    id uuid NOT NULL,
    createdat TIMESTAMP NOT NULL,
    collaboratorid uuid NOT NULL,
    carid uuid NOT NULL,
    startedat TIMESTAMP,
    finishedat TIMESTAMP,

    PRIMARY KEY (id),
    CONSTRAINT fk_collaborator FOREIGN KEY(collaboratorid) REFERENCES collaborator(id),
    CONSTRAINT fk_car FOREIGN KEY(carid) REFERENCES car(id)
);
CREATE TABLE service_parts (
    partid uuid NOT NULL,
    serviceid uuid NOT NULL,
    quantity integer NOT NULL,

    CONSTRAINT fk_part FOREIGN KEY(partid) REFERENCES part(id),
    CONSTRAINT fk_service FOREIGN KEY(serviceid) REFERENCES service(id)
);

COPY client(id, createdat, name)
FROM '/files/clients.csv'
DELIMITER ','
CSV HEADER;

COPY collaborator(id, createdat, name)
FROM '/files/collaborator.csv'
DELIMITER ','
CSV HEADER;

COPY car(id, ownerid, createdat, model, year)
FROM '/files/car.csv' 
DELIMITER ','
CSV HEADER;

COPY part(id, createdat, name, price)
FROM '/files/part.csv' 
DELIMITER ','
CSV HEADER;