DELIMITER $$

ALTER ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY INVOKER VIEW `actor_info` AS 
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
     ON ((`fc`.`category_id` = `c`.`category_id`)))$$

DELIMITER ;