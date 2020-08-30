# CartManagement


cartdb=# \dt
            List of relations
 Schema |     Name     | Type  |  Owner   
--------+--------------+-------+----------
 public | cart_product | table | cartuser
 public | customer     | table | cartuser
 public | product      | table | cartuser
(3 rows)


cartdb=# SELECT * FROM "public".customer;
 id |     name      | email | phone_number  | record_status 
----+---------------+-------+---------------+---------------
  1 | Si Senor      | a@b   | +902122121212 | t
  2 | Bobby Firmino | a@b   | +902122121212 | t
(2 rows)


cartdb=# SELECT * FROM "public".product;
 id |     name      | description | price  | quantity | record_status 
----+---------------+-------------+--------+----------+---------------
  1 | Test Product  | Test        | 100.00 |        5 | t
  2 | Test Product1 | Test        |  10.00 |        5 | t
  3 | Test Product2 | Test        |   1.00 |        5 | t
  4 | Test Product3 | Test        |  50.00 |        5 | t
  5 | Test Product4 | Test        | 150.00 |        5 | t
(5 rows)
