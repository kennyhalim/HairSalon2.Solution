CREATE DATABASE bestrestaurants;
use bestrestaurants;
CREATE TABLE cuisine (id INT NOT NULL AUTO_INCREMENT, type VARCHAR(255) NOT NULL, PRIMARY KEY(id));
ALTER TABLE cuisine ADD restaurant_id INT;
CREATE TABLE restaurants (id serial PRIMARY KEY, name VARCHAR(255));
