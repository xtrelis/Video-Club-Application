SELECT
`c`.`name` AS `category`,
SUM(CASE WHEN p.`payment_date` BETWEEN '01-01-2016 00:00:00' AND '01-01-2017 00:00:00' THEN `p`.`amount` ELSE 0 END) AS `total_sales`
FROM `payment` `p`
JOIN `rental` `r`
ON `p`.`rental_id` = `r`.`rental_id`
JOIN `inventory` `i`
ON `r`.`inventory_id` = `i`.`inventory_id`
JOIN `film` `f`
ON `i`.`film_id` = `f`.`film_id`
JOIN `film_category` `fc`
ON `f`.`film_id` = `fc`.`film_id`
JOIN `category` `c`
ON `fc`.`category_id` = `c`.`category_id`
GROUP BY `c`.`name`
ORDER BY SUM(`p`.`amount`)DESC;

SELECT
`c`.`name` AS `category`,
SUM(`p`.`amount`) AS `total_sales`
FROM `payment` `p`
JOIN `rental` `r`
ON `p`.`rental_id` = `r`.`rental_id`
JOIN `inventory` `i`
ON `r`.`inventory_id` = `i`.`inventory_id`
JOIN `film` `f`
ON `i`.`film_id` = `f`.`film_id`
JOIN `film_category` `fc`
ON `f`.`film_id` = `fc`.`film_id`
JOIN `category` `c`
ON `fc`.`category_id` = `c`.`category_id`
WHERE p.`payment_date` BETWEEN '01-01-2016 00:00:00' AND '01-01-2017 00:00:00' 
GROUP BY `c`.`name`
ORDER BY SUM(`p`.`amount`)DESC;

SELECT
`c`.`name` AS `category`,
SUM(`p`.`amount`) AS `total_sales`
FROM `payment` `p`
JOIN `rental` `r`
ON `p`.`rental_id` = `r`.`rental_id`
JOIN `inventory` `i`
ON `r`.`inventory_id` = `i`.`inventory_id`
JOIN `film` `f`
ON `i`.`film_id` = `f`.`film_id`
JOIN `film_category` `fc`
ON `f`.`film_id` = `fc`.`film_id`
JOIN `category` `c`
ON `fc`.`category_id` = `c`.`category_id`
WHERE p.`payment_date` BETWEEN '01-01-2016 00:00:00' AND '01-01-2017 00:00:00' 
GROUP BY `c`.`name`
ORDER BY SUM(`p`.`amount`)DESC;