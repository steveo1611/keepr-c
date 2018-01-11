
-- USE THIS LINE FOR GET KEEPS BY VAULTID
SELECT * FROM vaultkeeps vk
INNER JOIN keeps k ON k.id = vk.keepId 
WHERE (vaultId = 2)
