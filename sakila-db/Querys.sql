
SELECT film.`film_id`,film.`title`,inventory.`inventory_id`
FROM film 
LEFT JOIN inventory ON film.film_id=inventory.film_id;

SELECT film.`film_id`,film.`title`,customer.`first_name`,customer.`first_name`, customer.`customer_id`
FROM film 
LEFT JOIN inventory ON film.film_id=inventory.film_id;

SELECT film.`film_id`,film.`title`,inventory.`inventory_id`
FROM film 
LEFT JOIN inventory ON film.film_id=inventory.film_id;

SELECT customer.`customer_id`,customer.`first_name`,customer.`last_name`,rental.`rental_id`,rental.`return_date`,inventory.`film_id`,film.`title`
FROM customer
JOIN rental ON customer.`customer_id`=rental.`customer_id`
JOIN inventory ON rental.`inventory`sakila`_id`=inventory.`inventory_id`
JOIN film ON inventory.`film_id`=film.`film_id`;

SELECT film.`film_id`,film.`title`,inventory.`inventory_id`
FROM film 
LEFT JOIN inventory ON film.film_id=inventory.film_id;

SELECT category.`category_id`,category.`name` FROM category;

SELECT film.`title`,
film.`description`,
category.`name`,
film.`release_year`,
film.`length`,
film.`rental_duration`,
film.`rental_rate`,
film.`special_features`,
film.`replacement_cost` 
FROM film
LEFT JOIN film_category 
ON film.`film_id`=film_category.`film_id`
LEFT JOIN category 
ON film_category.`category_id`=category.`category_id`;
--WHERE category.`category_id`=1; 

SELECT actor.`first_name`,actor.`last_name`
FROM actor
LEFT JOIN film_actor 
ON actor.`actor_id`=film_actor.`actor_id`
LEFT JOIN film 
ON film_actor.`film_id`=film.`film_id`
WHERE film.`title`='ACADEMY DINOSAUR';

SELECT payment.`rental_id`,rental.`rental_date`
FROM rental
LEFT JOIN payment 
ON rental.`rental_id`=payment.`rental_id`
WHERE payment.`rental_id` IS NULL;

 SELECT
  customer.`customer_id` AS ID,
  CONCAT(customer.`first_name`,_utf8' ',customer.`last_name`) AS `Full Name`,
  customer.`email` AS `E-Mail`,
  address.`address` AS `Address`,
  address.`postal_code` AS `Zip Code`,
  address.`phone` AS `Phone`,
  city.`city` AS City,
  country.`country` AS Country,
  IF(customer.`active`,_utf8'active',_utf8'') AS `Notes`,
  customer.`store_id` AS SID
  FROM customer 
  JOIN address 
  ON customer.`address_id`=address.`address_id`
  JOIN city 
  ON address.`city_id`=city.`city_id`
  JOIN country 
  ON city.`country_id`=country.`country_id`;
  
   SELECT
  `film`.`film_id`     AS `FID`,
  `film`.`title`       AS `title`,
  `film`.`description` AS `description`,
  `category`.`name`    AS `category`,
  `film`.`rental_rate` AS `price`,
  `film`.`length`      AS `length`,
  `film`.`rating`      AS `rating`,
  film.`special_features` AS special_features,
  film.`rental_duration` AS rental_duration,
  film.`replacement_cost`AS `replacement_cost`
  FROM category
  LEFT JOIN film_category ON category.`category_id`=film_category.`category_id`
  LEFT JOIN film ON film_category.`film_id`=film.`film_id`;
  
SELECT * FROM actor_info;

SELECT
  `a`.`actor_id`   AS `actor_id`,
  `a`.`first_name` AS `first_name`,
  `a`.`last_name`  AS `last_name`,
  GROUP_CONCAT(DISTINCT CONCAT(`c`.`name`,': ',(SELECT GROUP_CONCAT(`f`.`title` ORDER BY `f`.`title` ASC SEPARATOR ', ') FROM ((`film` `f` JOIN `film_category` `fc` ON((`f`.`film_id` = `fc`.`film_id`))) JOIN `film_actor` `fa` ON((`f`.`film_id` = `fa`.`film_id`))) WHERE ((`fc`.`category_id` = `c`.`category_id`) AND (`fa`.`actor_id` = `a`.`actor_id`)))) ORDER BY `c`.`name` ASC SEPARATOR '; ') AS `film_info`
FROM (((`actor` `a`
     LEFT JOIN `film_actor` `fa`
       ON ((`a`.`actor_id` = `fa`.`actor_id`)))
    LEFT JOIN `film_category` `fc`
      ON ((`fa`.`film_id` = `fc`.`film_id`)))
   LEFT JOIN `category` `c`
     ON ((`fc`.`category_id` = `c`.`category_id`)))
GROUP BY `a`.`actor_id`,`a`.`first_name`,`a`.`last_name`;

SELECT
  `c`.`name` AS `category`,
  SUM(`p`.`amount`) AS `total_sales`
FROM (((((`payment` `p`
       JOIN `rental` `r`
         ON ((`p`.`rental_id` = `r`.`rental_id`)))
      JOIN `inventory` `i`
        ON ((`r`.`inventory_id` = `i`.`inventory_id`)))
     JOIN `film` `f`
       ON ((`i`.`film_id` = `f`.`film_id`)))
    JOIN `film_category` `fc`
      ON ((`f`.`film_id` = `fc`.`film_id`)))
   JOIN `category` `c`
     ON ((`fc`.`category_id` = `c`.`category_id`)))
GROUP BY `c`.`name`
ORDER BY SUM(`p`.`amount`)DESC;

CONCAT(`c`.`city`,_utf8',',`cy`.`country`) AS `store`,
  CONCAT(`m`.`first_name`,_utf8' ',`m`.`last_name`) AS `manager`,
  SUM(`p`.`amount`) AS `total_sales`
FROM (((((((`payment` `p`
         JOIN `rental` `r`
           ON ((`p`.`rental_id` = `r`.`rental_id`)))
        JOIN `inventory` `i`
          ON ((`r`.`inventory_id` = `i`.`inventory_id`)))
       JOIN `store` `s`
         ON ((`i`.`store_id` = `s`.`store_id`)))
      JOIN `address` `a`
        ON ((`s`.`address_id` = `a`.`address_id`)))
     JOIN `city` `c`
       ON ((`a`.`city_id` = `c`.`city_id`)))
    JOIN `country` `cy`
      ON ((`c`.`country_id` = `cy`.`country_id`)))
   JOIN `staff` `m`
     ON ((`s`.`manager_staff_id` = `m`.`staff_id`)))
GROUP BY `s`.`store_id`
ORDER BY `cy`.`country`,`c`.`city`;

SELECT
  `s`.`staff_id`      AS `ID`,
  CONCAT(`s`.`first_name`,_utf8' ',`s`.`last_name`) AS `name`,
  `a`.`address`       AS `address`,
  `a`.`postal_code`   AS `zip code`,
  `a`.`phone`         AS `phone`,
  `city`.`city`       AS `city`,
  `country`.`country` AS `country`,
  `s`.`store_id`      AS `SID`
FROM (((`staff` `s`
     JOIN `address` `a`
       ON ((`s`.`address_id` = `a`.`address_id`)))
    JOIN `city`
      ON ((`a`.`city_id` = `city`.`city_id`)))
   JOIN `country`
     ON ((`city`.`country_id` = `country`.`country_id`)));
     
     SELECT rental.`rental_id` FROM rental 
     LEFT JOIN payment ON rental.`rental_id`=payment.`rental_id`
     WHERE payment.`rental_id` IS NULL;
     
     SELECT * FROM rental WHERE rental.`return_date` IS NULL;
     
 