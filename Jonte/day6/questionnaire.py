from data import data
import itertools

items = data.split('\n\n')

def count_answers(item):
    individual_answers = [list(ans) for ans in item.split('\n')]    
    
    # flatten nested list
    all_answers = set(itertools.chain(*individual_answers))
    
    return len(all_answers)

print(sum([count_answers(item) for item in items]))


def count_answers_2(item):
    individual_answers = [list(ans) for ans in item.split('\n')]    
    
    # flatten nested list
    all_answers = set(itertools.chain(*individual_answers))    
    
    return sum([all(c in ia for ia in individual_answers) for c in all_answers])

print(sum([count_answers_2(item) for item in items]))