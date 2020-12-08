#include <iostream>
#include <numeric>
#include <algorithm>
#include <unordered_map>

#include "../util.hpp"

using std::string;
using std::vector;

using child_list = vector<std::pair<int, string>>;
using dict = std::unordered_map<string, child_list>;

dict build_tree(const vector<string>& lines) {
  std::string delimiter = " contain ";  
  const std::regex parent_regex("(.+) bag");
  const std::regex child_regex("(\\d+) (.+) bag");

  dict d;

  for (const auto& line : lines) {
    // parse line
    auto n = line.find(delimiter);
    auto s0 =  line.substr(0, n);
    auto s1 =  line.substr(n + delimiter.size());

    auto m0 = util::re_search(parent_regex, s0);

    const auto child_strings = util::split(s1, ',');
    child_list children;
    for (const auto& cs : child_strings) {
        auto m1 = util::re_search(child_regex, cs);
        if(m1.size() == 3) {
            children.push_back({std::stoi(m1[1]), m1[2]});
        }
    } 
    
    d[m0[1]] = children;
  }

  return d;
}

bool has_bag(const string& container_bag, const string& query_bag,
             const dict& tree_dict) {
  if (tree_dict.count(container_bag) == 0) {
    return false;
  }

  const auto children = tree_dict.at(container_bag);

  if (util::contains(children,
                     [&](const auto& c) { return c.second == query_bag; })) {
    return true;
  }

  // recursive call
  for (const auto& c : children) {
      if (has_bag(c.second, query_bag, tree_dict)) {
          return true;
      }
  }

  return false;
}

int count_bags(const string& s, const dict& tree_dict) {
  const auto children = tree_dict.at(s);
  return std::accumulate(children.begin(), children.end(), 0,
                         [&tree_dict](int sum, const auto& child) {
                           const auto& [n, name] = child;
                           return sum + n * (1 + count_bags(name, tree_dict));
                         });
}

int main() {
  const auto data = util::read_text_file("data.txt");
  const auto lines = util::split(data, '\n');

  const auto tree = build_tree(lines);

  // part 1
  int count = 0;
  for (const auto& [k, v] : tree) {
    if (has_bag(k, "shiny gold", tree)) {
      ++count;
    }
  }
  std::cout << count << std::endl;

  // part 2
  std::cout << count_bags("shiny gold", tree) << std::endl;
}