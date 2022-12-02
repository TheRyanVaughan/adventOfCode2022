path = './input.txt'
lens = []
with open(path) as f:
    s = 0
    for line in f:
        if len(line) == 1:
            lens.append(s)
            s = 0
        else:
            s += int(line.strip())
print(max(lens))

# pt 2: sum of top 3
print(sum(sorted(lens)[-3::]))
