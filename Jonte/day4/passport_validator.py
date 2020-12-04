from data import data as raw_data
import re

data = raw_data.split('\n\n')
required_fields = ['byr', 'iyr', 'eyr', 'hgt', 'hcl', 'ecl', 'pid']

# part 1
def validate_entry(e):
    fields = re.findall(r"\w+(?=:)", e)
    
    for f in required_fields:
        if f not in fields:
            return False
        
    return True  
        
print(sum([validate_entry(d) for d in data]))

# part 2
def validate_byr(s):
    return 1920 <= int(s) <= 2002

def validate_iyr(s):
    return 2010 <= int(s) <= 2020

def validate_eyr(s):
    return 2020 <= int(s) <= 2030

def validate_hgt(s):
    match_cm = re.findall('^(\d+)cm$', s)
    if match_cm:
        return 150 <= int(match_cm[0]) <= 193
    
    match_in = re.findall('^(\d+)in$', s)
    if match_in:
        return 59 <= int(match_in[0]) <= 76 
    
    return False

def validate_hcl(s):
    return not not re.findall('^#([0-9]|[a-f]){6}$', s)

def validate_ecl(s):
    return s in ['amb', 'blu', 'brn', 'gry', 'grn', 'hzl', 'oth']

def validate_pid(s):
    return not not re.findall('^[0-9]{9}$', s)

validation_functions = {'byr': validate_byr,
                        'iyr': validate_iyr,
                        'eyr': validate_eyr,
                        'hgt': validate_hgt,
                        'hcl': validate_hcl,
                        'ecl': validate_ecl,
                        'pid': validate_pid}

def validate_entry_2(e):
    fields = dict(re.findall(r"(\w+):(#*\d*\w*)", e))    
  
    for f in required_fields:
        if f not in fields:
            return False
        else:
            func = validation_functions[f]
            if not func(fields[f]):
                return False
        
    return True

print(sum([validate_entry_2(d) for d in data]))