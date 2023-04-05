WITH valid_votes AS (
SELECT v.voter, v.quality,
CONCAT(p.First_Name, ' ', p.Last_Name) AS name, p.Locatie AS location,
MONTH(v.voting_date) AS month,
YEAR(v.voting_date) AS year,
CASE
WHEN MONTH(v.voting_date) BETWEEN 1 AND 3 THEN 'Q1'
WHEN MONTH(v.voting_date) BETWEEN 4 AND 6 THEN 'Q2'
WHEN MONTH(v.voting_date) BETWEEN 7 AND 9 THEN 'Q3'
WHEN MONTH(v.voting_date) BETWEEN 10 AND 12 THEN 'Q4'
END AS quarter FROM votes v 
JOIN persons p ON v.voter = p.ID 
WHERE v.valid = '1' AND YEAR(v.voting_date) = 2022), report AS ( 
SELECT quality, 
COUNT(*) AS number, location, month AS period, name FROM valid_votes
GROUP BY quality, location, month, name
UNION ALL
SELECT quality,
COUNT(*) AS number,location,quarter AS period,name FROM valid_votes
GROUP BY quality, location, quarter, name
UNION ALL
SELECT quality,
COUNT(*) AS number, location, year AS period, name FROM valid_votes
GROUP BY quality, location, year, name )
SELECT * FROM report;
