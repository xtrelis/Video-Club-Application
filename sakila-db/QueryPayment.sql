SELECT payment.`payment_id`,customer.`first_name`,customer.`last_name`,customer.`email`,film.`title`,payment.`amount`,payment.`payment_date`
FROM payment
LEFT JOIN customer ON payment.`customer_id`=customer.`customer_id`
LEFT JOIN rental ON customer.`customer_id`=rental.`customer_id`
LEFT JOIN inventory ON rental.`inventory_id`=inventory.`inventory_id`
LEFT JOIN film ON inventory.`film_id`=film.`film_id`;

SELECT payment.`payment_id`,
CONCAT(customer.`first_name`,' ', customer.`last_name`) AS Customer,
customer.`email`,
payment.`amount`,
store.`store_id`,
payment.`payment_date`, 
address.`address` AS StoreAddress
FROM payment
LEFT JOIN customer ON payment.`customer_id`=customer.`customer_id`
LEFT JOIN store ON customer.`store_id`=store.`store_id`
LEFT JOIN address ON store.`address_id`=address.`address_id`;

SELECT payment.`payment_id`,
CONCAT(customer.`first_name`,' ', customer.`last_name`) AS Customer,
address.`phone`,
payment.`amount`,
payment.`payment_date`,
CONCAT(staff.`first_name`,' ', staff.`last_name`) AS Staff, 
store.`store_id`
FROM payment
LEFT JOIN staff ON payment.`staff_id`= staff.`staff_id`
LEFT JOIN store ON staff.`store_id`=store.`store_id`
LEFT JOIN customer ON store.`store_id`=customer.`store_id`
LEFT JOIN Address ON customer.`address_id`=address.`address_id`;