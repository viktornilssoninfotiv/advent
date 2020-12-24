#include <iostream>
#include <algorithm>
#include <regex>
#include <sstream>
#include <fstream>
#include <string>
#include <vector>
#include <chrono>

namespace cs = std::chrono;

namespace util {

std::vector<std::string> re_search(const std::regex& r,
                                   const std::string& s) {
  std::vector<std::string> out;
  
  if (std::smatch m; std::regex_search(s, m, r)) {
    for (const auto& sub_match : m) {
      out.push_back(sub_match.str());
    }
  }

  return out;
}

template<class String>
std::string read_text_file(const String& str) {
  std::ifstream ifs(str);
  std::string content{std::istreambuf_iterator<char>(ifs),
                      std::istreambuf_iterator<char>()};
  return content;
}

std::vector<std::string> split(const std::string& str, char delimiter) {
  std::vector<std::string> tokens;
  
  std::istringstream iss(str);

  std::string token;
  while (std::getline(iss, token, delimiter)) {
    tokens.push_back(token);
  }

  return tokens;
}

/* functional */
template <class Container, class Pred>
bool all(const Container& c, Pred p) {
  for (const auto& item : c) {
    if (!p(item)) {
      return false;
    }
  }
  return true;
}

template <class Container, class Pred>
bool any(const Container& c, Pred p) {
  for (const auto& item : c) {
    if (p(item)) {
      return true;
    }
  }
  return false;
}

template <class Container, class Pred>
bool contains(const Container& c, Pred p) {
    auto it = std::find_if(c.begin(), c.end(), p);
    return it != c.end();
}

template<class Container, class Func>
auto map(const Container& c, Func f) {
    using T = decltype(f(*c.begin()));
    
    std::vector<T> out;
    for (const auto& item : c) {
        out.emplace_back(f(c));
    }

    return out;
}

} // namespace util

