module Main (main) where

import Text.Read;

split :: Char -> String -> [String]
split _ [] = [""]
split delimeter (c:cs) | c == delimeter  = "" : rest
             | otherwise = (c : head rest) : tail rest
    where rest = split delimeter cs

removeCardNumber :: String -> String
removeCardNumber (':':cs) = cs
removeCardNumber (c:cs) = removeCardNumber cs

matchingNumbers :: [Int] -> [Int] -> Int
matchingNumbers [] _ = 0
matchingNumbers (i:is) others = length ((filter (i ==) others)) + (matchingNumbers is others)

score :: Int -> Int
score 0 = 0
score n = 2^(n-1)

readInts :: String -> [Int]
readInts numbers = filterNothing (ri numbers [] []) where
  ri :: String -> String -> [Maybe Int] -> [Maybe Int]
  ri [] [] ints = ints
  ri [] acc ints = ((readMaybe (reverse acc) :: Maybe Int):ints)
  ri (' ':sleft) acc ints = ri sleft [] ((readMaybe (reverse acc) :: Maybe Int):ints)
  ri (c:sleft)   acc ints = ri sleft (c:acc) ints
  filterNothing :: [Maybe a] -> [a]
  filterNothing [] = []
  filterNothing ((Just a):as) = a:(filterNothing as)
  filterNothing (Nothing:as) = filterNothing as

main :: IO ()
main = do
  contents <- readFile "data.txt"
  let lines = split '\n' contents
  let formattedLines = map removeCardNumber lines
  let halves = map (split '|') formattedLines
  let numberHalves = map (map readInts) halves
  let matches = [matchingNumbers (x!!0) (x!!1) | x <- numberHalves]
  let scores = map score matches
  print (sum scores)