USE final_capstone
GO

DROP TABLE IF EXISTS sales;
DROP TABLE IF EXISTS loss;
DROP TABLE IF EXISTS waste;
DROP TABLE IF EXISTS inventory;
DROP TABLE IF EXISTS harvests;
DROP TABLE IF EXISTS crop_plans;
DROP TABLE IF EXISTS crops;

--creating tables

--Default values will be 0 for the uploaded properties since the CSV files only have one property in each.

CREATE TABLE crops (
crop_id int IDENTITY(1,1) NOT NULL,
crop_name varchar(50) NOT NULL,
time_seed_to_transplant int DEFAULT 0,
time_transplant_to_harvest int DEFAULT 0,
time_seed_to_harvest int DEFAULT 0,
time_to_expire int DEFAULT 0,
PRIMARY KEY (crop_id)
);
GO
--Default values not necessary since we have all info in one CSV file.

CREATE TABLE crop_plans (
plan_id int IDENTITY(1,1) NOT NULL,
crop_id int NOT NULL,
area_identifier varchar(50) NOT NULL,
planting_date date NOT NULL,
PRIMARY KEY (plan_id),
FOREIGN KEY (crop_id) REFERENCES crops(crop_id)
);
GO

--The user will input data for these through the application as there is no mention of uploading CSV files in the user story.

CREATE TABLE harvests (
harvest_id int IDENTITY(1,1) NOT NULL,
crop_id int NOT NULL,
area_identifier varchar(50) NOT NULL,
weight_count decimal NOT NULL,
date_harvested date NOT NULL,
PRIMARY KEY (harvest_id),
FOREIGN KEY (crop_id) REFERENCES crops(crop_id)
);
GO

CREATE TABLE inventory (
inventory_id int IDENTITY(1,1) NOT NULL,
crop_id int NOT NULL,
amount decimal NOT NULL CHECK (amount >= 0),
date_added date NOT NULL,

PRIMARY KEY (inventory_id),
FOREIGN KEY (crop_id) REFERENCES crops(crop_id)
);
GO
CREATE TABLE sales (
sale_id int IDENTITY(1,1) NOT NULL,
inventory_id int NOT NULL,
date_sold date NOT NULL,
amount_sold decimal NOT NULL,
revenue decimal NOT NULL,
method_of_sale varchar(50),
PRIMARY KEY (sale_id),
FOREIGN KEY (inventory_id) REFERENCES inventory(inventory_id)
);
GO
CREATE TABLE loss (
loss_id int IDENTITY(1,1) NOT NULL,
inventory_id int NOT NULL,
date_lost date NOT NULL,
amount_lost decimal NOT NULL,
loss_description varchar(50),
PRIMARY KEY (loss_id),
FOREIGN KEY (inventory_id) REFERENCES inventory(inventory_id)
);
GO
CREATE TABLE waste (
waste_id int IDENTITY(1,1) NOT NULL,
inventory_id int NOT NULL,
date_wasted date NOT NULL,
amount_wasted decimal NOT NULL,
waste_description varchar(50),
PRIMARY KEY (waste_id),
FOREIGN KEY (inventory_id) REFERENCES inventory(inventory_id)
);
GO
--adding default data

INSERT INTO crops (crop_name, time_seed_to_transplant, time_transplant_to_harvest, time_seed_to_harvest, time_to_expire) 
VALUES ('corn', 14, 13, 27, 16), ('wheat', 130, 80, 210, 62), ('onions', 15, 15, 15, 15), ('spinach', 60, 30, 45, 90);

INSERT INTO crop_plans (crop_id, area_identifier, planting_date)
VALUES (2, 'southwest', '08/31/2020');

INSERT INTO harvests (crop_id, area_identifier, weight_count, date_harvested)
VALUES (1, 'north', 350, '06/22/2020');

INSERT INTO inventory (crop_id, date_added, amount)
VALUES (1, '06/22/2020', 303);

INSERT INTO sales (inventory_id, date_sold, amount_sold, revenue, method_of_sale)
VALUES (1, '06/25/2020', 32, 62.67, 'retail');

INSERT INTO loss (inventory_id, date_lost, amount_lost, loss_description)
VALUES (1, '06/27/2020', 4, 'theft');

INSERT INTO waste (inventory_id, date_wasted, amount_wasted, waste_description)
VALUES (1, '07/08/2020', 11, 'expired');

INSERT INTO crop_plans (crop_id, area_identifier, planting_date)
VALUES (2, 'northeast', '08/10/2020');

IF EXISTS (SELECT * FROM crops WHERE crop_name = 'squash')
BEGIN
UPDATE crops SET time_to_expire = 35 WHERE crop_name = 'squash'
END
ELSE
BEGIN
INSERT INTO crops (crop_name, time_to_expire) VALUES ('squash', 35)
END;

SELECT i.inventory_id, i.date_added, c.crop_name, l.date_lost, l.amount_lost, l.loss_description FROM loss AS l JOIN inventory AS i ON l.inventory_id = i.inventory_id JOIN crops AS c ON i.crop_id = c.crop_id;

