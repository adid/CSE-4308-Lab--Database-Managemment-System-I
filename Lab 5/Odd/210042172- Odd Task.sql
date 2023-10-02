--TASK 1
SELECT first_name, COUNT(*) AS count FROM actresses
GROUP BY first_name HAVING COUNT(*) > 1;

--TASK 2
SELECT MOV_TITLE FROM MOVIE
WHERE MOV_ID NOT IN 
(SELECT MOV_ID FROM RATING);

--TASK 3
SELECT EXTRACT(MONTH FROM MOV_RELEASEDATE) AS RELEASE_MONTH, COUNT(*) AS MOVIE_COUNT FROM MOVIE
GROUP BY EXTRACT(MONTH FROM MOV_RELEASEDATE) ORDER BY RELEASE_MONTH;

--TASK 4


--TASK 5
SELECT M.MOV_TITLE, AVG(R.REV_STARS) AS AVERAGE_RATING FROM 
MOVIE M NATURAL JOIN RATING R
GROUP BY M.MOV_TITLE HAVING AVG(R.REV_STARS) > 7;

--TASK 6
SELECT REV_NAME FROM REVIEWER
WHERE REV_ID IN (SELECT REV_ID FROM RATING
WHERE REV_STARS = (SELECT MIN(REV_STARS) FROM RATING)
GROUP BY REV_ID HAVING COUNT(*) = (SELECT MAX(COUNT(*))
FROM (SELECT REV_ID, COUNT(*) AS COUNT FROM RATING
WHERE REV_STARS = (SELECT MIN(REV_STARS) FROM RATING)
GROUP BY REV_ID)));

--TASK 7
SELECT M.MOV_TITLE, COALESCE(AVG(R.REV_STARS), 0) AS AVERAGE_RATING
FROM MOVIE M NATURAL JOIN RATING R
GROUP BY M.MOV_TITLE;

--TASK 8   
SELECT DISTINCT D.DIR_FIRSTNAME || ' ' || D.DIR_LASTNAME AS DIRECTOR_NAME
FROM DIRECTOR D JOIN MOVIE M ON D.DIR_ID = M.DIR_ID NATURAL JOIN RATING R
WHERE R.REV_STARS > (SELECT AVG(REV_STARS) FROM RATING)
AND D.DIR_FIRSTNAME LIKE 'Sr.%';