USE inventory

DROP TABLE IF EXISTS orders
DROP TABLE IF EXISTS items;
DROP TABLE IF EXISTS suppliers
DROP TABLE IF EXISTS images
DROP TABLE IF EXISTS users

--
-- Table structure for table suppliers
--
CREATE TABLE suppliers (
  id int NOT NULL IDENTITY,
  name varchar(45) DEFAULT NULL,
  contact varchar(45) DEFAULT NULL,
  address varchar(45) DEFAULT NULL,
  PRIMARY KEY (id))

--
-- Table structure for table images
--

CREATE TABLE images (
  id int NOT NULL IDENTITY,
  description varchar(45) DEFAULT NULL,
  image_name varchar(45) DEFAULT NULL,
  item_id int DEFAULT NULL,
  PRIMARY KEY (id)
)

--
-- Table structure for table items
--

CREATE TABLE items (
  id int NOT NULL IDENTITY,
  category varchar(45) DEFAULT NULL,
  name varchar(45) NOT NULL,
  description text,
  price decimal DEFAULT NULL,
  quantity int DEFAULT NULL,
  total decimal DEFAULT NULL,
  supplier_id int DEFAULT NULL FOREIGN KEY REFERENCES suppliers(id),
  PRIMARY KEY (id)
)

--
-- Table structure for table orders
--

CREATE TABLE orders (
  id int NOT NULL IDENTITY,
  name varchar(45) DEFAULT NULL,
  contact varchar(45) DEFAULT NULL,
  item_id int DEFAULT NULL FOREIGN KEY REFERENCES items(id),
  description varchar(45) DEFAULT NULL,
  quantity int DEFAULT NULL,
  price decimal DEFAULT NULL,
  tax decimal DEFAULT NULL,
  total decimal DEFAULT NULL,
  PRIMARY KEY (id),
)

--
-- Table structure for table users
--

CREATE TABLE users (
  id int NOT NULL IDENTITY,
  name varchar(45) DEFAULT NULL,
  username varchar(45) DEFAULT NULL,
  email varchar(45) DEFAULT NULL,
  password varchar(45) NOT NULL,
  contact varchar(45) DEFAULT NULL,
  PRIMARY KEY (id)
)
