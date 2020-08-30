\connect cartdb

CREATE TABLE  customer (
    id serial PRIMARY KEY,
    name VARCHAR (50) NOT NULL,
    email VARCHAR (50) NOT NULL,
    phone_number VARCHAR (50) NOT NULL,
    record_status boolean NOT NULL
);

CREATE TABLE  product (
    id serial PRIMARY KEY,
    name VARCHAR (50) NOT NULL,
    description VARCHAR (200) NOT NULL,
    price NUMERIC (5, 2) NOT NULL,
    quantity INTEGER NOT NULL,
    record_status boolean NOT NULL
);

CREATE TABLE cart_product
(
    id serial PRIMARY KEY,
    user_id INTEGER NOT NULL,
    product_id  INTEGER NOT NULL,
    quantity INTEGER NOT NULL,
    record_status boolean NOT NULL
);

ALTER TABLE "customer" OWNER TO cartuser;
ALTER TABLE "product" OWNER TO cartuser;
ALTER TABLE "cart_product" OWNER TO cartuser;


Insert into customer(name,email,phone_number,record_status) values( 'Si Senor','a@b', '+902122121212', true);
Insert into customer(name,email,phone_number,record_status) values( 'Bobby Firmino', 'a@b', '+902122121212', true);


Insert into product(name,description,price,quantity,record_status) values( 'Test Product', 'Test', 100.00, 5, true);
Insert into product(name,description,price,quantity,record_status) values( 'Test Product1', 'Test', 10.00, 5, true);
Insert into product(name,description,price,quantity,record_status) values( 'Test Product2', 'Test', 1.00, 5, true);
Insert into product(name,description,price,quantity,record_status) values( 'Test Product3', 'Test', 50.00, 5, true);
Insert into product(name,description,price,quantity,record_status) values( 'Test Product4', 'Test', 150.00, 5, true);
