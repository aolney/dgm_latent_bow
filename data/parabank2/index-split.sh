lineCount=$(wc -l < train.txt)
tenPercent=$(echo $lineCount*.10 | bc)
echo "$lineCount lines"
echo "$tenPercent for test"
#split into 10% and 90%
seq 0 1 $lineCount | shuf | csplit - -s ${tenPercent%.*}
