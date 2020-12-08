#include <fstream>
#include <iostream>
#include <numeric>
#include <algorithm>
#include <string>
#include <unordered_map>
#include <vector>

using std::pair;
using std::string;
using std::vector;

struct bag {
  string id;
  vector<pair<int, string>> children;
};

bag parse_line(const string& line) {
  // split at contains

  //

  return {"", {}};
}

using dict = std::unordered_map<string, vector<pair<int, string>>>;

dict build_tree(const vector<string>& lines) {
  dict d;

  for (const auto& line : lines) {
    const auto [id, children] = parse_line(line);
    d[id] = children;
  }

  return d;
}

bool has_bag(const string& container_bag, const string& query_bag,
             const dict& tree_dict) {
  if (tree_dict.count(container_bag) == 0) {
    return false;
  }

  const auto children = tree_dict.at(container_bag);

  auto it = std::find_if(children.begin(), children.end(),
                         [&](const auto& c) { return c.second == query_bag; });
  if (it != children.end()) {
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
  vector<string> lines;
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