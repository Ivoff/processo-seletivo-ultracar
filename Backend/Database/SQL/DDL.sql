CREATE DATABASE services_manager;
\c services_manager;
CREATE TABLE client (
    id uuid NOT NULL,
    created_at TIMESTAMP NOT NULL,
    name VARCHAR NOT NULL,

    PRIMARY KEY (id)
);
CREATE TABLE collaborator (
    id uuid NOT NULL,
    created_at TIMESTAMP NOT NULL,
    name VARCHAR NOT NULL,

    PRIMARY KEY (id)
);
CREATE TABLE car (
    id uuid NOT NULL,
    created_at TIMESTAMP NOT NULL,
    owner_id uuid NOT NULL,
    model VARCHAR NOT NULL,
    year VARCHAR NOT NULL,    
    
    PRIMARY KEY (id),
    CONSTRAINT fk_owner FOREIGN KEY(owner_id) REFERENCES client(id)
);
CREATE TABLE part (
    id uuid NOT NULL,
    created_at TIMESTAMP NOT NULL,
    name VARCHAR NOT NULL,
    price decimal NOT NULL,
    quantity integer NOT NULL,

    PRIMARY KEY (id)
);
CREATE TABLE service (
    id uuid NOT NULL,
    created_at TIMESTAMP NOT NULL,
    collaborator_id uuid NOT NULL,
    car_id uuid NOT NULL,
    started_at TIMESTAMP NOT NULL,
    finished_at TIMESTAMP NOT NULL,

    PRIMARY KEY (id),
    CONSTRAINT fk_collaborator FOREIGN KEY(collaborator_id) REFERENCES collaborator(id),
    CONSTRAINT fk_car FOREIGN KEY(car_id) REFERENCES car(id)
);
CREATE TABLE service_parts (
    part_id uuid NOT NULL,
    service_id uuid NOT NULL,

    CONSTRAINT fk_part FOREIGN KEY(part_id) REFERENCES part(id),
    CONSTRAINT fk_service FOREIGN KEY(service_id) REFERENCES service(id)
);