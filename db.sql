-- phpMyAdmin SQL Dump
-- version 3.3.9
-- http://www.phpmyadmin.net
--
-- Host: localhost
-- Generation Time: Jun 05, 2011 at 06:25 PM
-- Server version: 5.5.8
-- PHP Version: 5.3.5

SET SQL_MODE="NO_AUTO_VALUE_ON_ZERO";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Database: `reach`
--

-- --------------------------------------------------------

--
-- Table structure for table `domain`
--

CREATE TABLE IF NOT EXISTS `domain` (
  `id_domain` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `name_domain` varchar(50) NOT NULL,
  PRIMARY KEY (`id_domain`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=7 ;

--
-- Dumping data for table `domain`
--

INSERT INTO `domain` (`id_domain`, `name_domain`) VALUES
(1, 'Algorithms'),
(2, 'C'),
(3, 'C++'),
(4, 'Java'),
(5, 'OOP'),
(6, 'PHP');

-- --------------------------------------------------------

--
-- Table structure for table `domain_question`
--

CREATE TABLE IF NOT EXISTS `domain_question` (
  `id_question` int(10) unsigned NOT NULL,
  `id_domain` int(10) unsigned NOT NULL,
  PRIMARY KEY (`id_question`,`id_domain`),
  KEY `fk_domain_question_question` (`id_question`),
  KEY `fk_domain_question_domain` (`id_domain`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `domain_question`
--

INSERT INTO `domain_question` (`id_question`, `id_domain`) VALUES
(60, 3),
(61, 3),
(62, 6),
(63, 6),
(64, 6),
(65, 3),
(66, 1),
(66, 4),
(67, 1),
(68, 1),
(69, 2),
(69, 3),
(70, 2),
(71, 2),
(72, 4),
(72, 5),
(73, 3),
(73, 5),
(74, 4),
(74, 5),
(75, 5),
(76, 6),
(77, 2),
(77, 3);

-- --------------------------------------------------------

--
-- Table structure for table `domain_quiz_item`
--

CREATE TABLE IF NOT EXISTS `domain_quiz_item` (
  `id_quiz_item` int(10) unsigned NOT NULL,
  `id_domain` int(10) unsigned NOT NULL,
  PRIMARY KEY (`id_quiz_item`,`id_domain`),
  KEY `fk_domain_quiz_item_quiz_item` (`id_quiz_item`),
  KEY `fk_domain_quiz_item_domain` (`id_domain`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `domain_quiz_item`
--

INSERT INTO `domain_quiz_item` (`id_quiz_item`, `id_domain`) VALUES
(1, 3),
(2, 3),
(3, 3),
(4, 3),
(5, 3),
(6, 3),
(7, 3),
(8, 1),
(9, 1),
(10, 1),
(11, 1),
(12, 1),
(13, 1),
(14, 2),
(15, 2),
(16, 2),
(17, 2),
(18, 2),
(19, 2),
(20, 2),
(21, 4),
(22, 4),
(23, 4),
(24, 4),
(25, 4),
(26, 4),
(27, 4),
(29, 6),
(30, 6),
(31, 6),
(32, 6),
(33, 6),
(34, 6),
(35, 6),
(36, 5),
(37, 5),
(38, 5),
(39, 5),
(40, 5),
(41, 5);

-- --------------------------------------------------------

--
-- Table structure for table `friendship`
--

CREATE TABLE IF NOT EXISTS `friendship` (
  `id_former_user` int(10) unsigned NOT NULL,
  `id_latter_user` int(10) unsigned NOT NULL,
  `status_friendship` tinyint(1) DEFAULT NULL,
  PRIMARY KEY (`id_latter_user`,`id_former_user`),
  KEY `fk_friendship_user1` (`id_former_user`),
  KEY `fk_friendship_user2` (`id_latter_user`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `friendship`
--

INSERT INTO `friendship` (`id_former_user`, `id_latter_user`, `status_friendship`) VALUES
(1, 2, 0),
(1, 3, 1),
(21, 3, 0),
(2, 4, 1),
(21, 4, 0),
(1, 5, 1),
(3, 5, 1),
(4, 5, 1),
(21, 5, 0),
(1, 6, 1),
(2, 6, 1),
(3, 6, 1),
(1, 7, 1),
(2, 7, 1),
(1, 8, 0),
(2, 8, 0),
(3, 8, 0),
(7, 8, 0),
(11, 8, 0),
(1, 9, 0),
(3, 9, 0),
(11, 9, 0),
(1, 10, 1),
(1, 11, 1),
(20, 11, 1),
(1, 12, 0),
(11, 12, 0),
(1, 13, 0),
(11, 13, 0),
(1, 14, 0),
(1, 15, 0),
(1, 16, 0),
(11, 16, 0),
(1, 17, 0),
(21, 19, 0),
(1, 21, 0),
(20, 21, 0);

-- --------------------------------------------------------

--
-- Table structure for table `log`
--

CREATE TABLE IF NOT EXISTS `log` (
  `id_log` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `question_question` int(10) unsigned NOT NULL,
  `owner_user` int(10) unsigned NOT NULL,
  `timestamp_log` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `content_log` varchar(10000) NOT NULL,
  PRIMARY KEY (`id_log`),
  KEY `fk_log_owner` (`owner_user`),
  KEY `fk_log_question` (`question_question`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=87 ;

--
-- Dumping data for table `log`
--

INSERT INTO `log` (`id_log`, `question_question`, `owner_user`, `timestamp_log`, `content_log`) VALUES
(57, 60, 13, '2011-06-05 16:08:53', '{\\rtf1\\ansi\\ansicpg1250\\deff0\\deflang1048{\\fonttbl{\\f0\\fnil\\fcharset238 Microsoft Sans Serif;}{\\f1\\fnil\\fcharset238{\\*\\fname Courier New;}Courier New CE;}}\r\n{\\colortbl ;\\red169\\green169\\blue169;}\r\n\\viewkind4\\uc1\\pard\\f0\\fs17 You can''t use \\cf1\\f1\\fs16 connect \\cf0\\f0\\fs17 like that. You cannot pass parameters to the \\cf1\\f1\\fs16 SLOT\\cf0\\f0\\fs17  that are not present in the connected \\cf1\\f1\\fs16 SIGNAL.\\par\r\n\\cf0\\f0\\fs17\\par\r\nYou will need to connect the \\cf1\\f1\\fs16 clicked()\\cf0\\f0\\fs17  signal to your own slot (with no argument), and call the \\cf1\\f1\\fs16 setPlainText \\cf0\\f0\\fs17 function yourself (or emit a new signal that has a \\cf1\\f1\\fs16 QString \\cf0\\f0\\fs17 parameter).\\par\r\n\\par\r\nThe other option is to use a \\cf1\\f1\\fs16 QSignalMapper\\cf0\\f0\\fs17 , as described in the \\cf1\\f1\\fs16 Signals and Slots \\cf0\\f0\\fs17 advanced usage section.\\par\r\n}\r\n'),
(58, 60, 8, '2011-06-05 16:10:44', '{\\rtf1\\ansi\\ansicpg1250\\deff0\\deflang1048{\\fonttbl{\\f0\\fnil\\fcharset238 Microsoft Sans Serif;}{\\f1\\fnil\\fcharset238{\\*\\fname Courier New;}Courier New CE;}}\r\n{\\colortbl ;\\red169\\green169\\blue169;}\r\n\\viewkind4\\uc1\\pard\\f0\\fs17 I think that won''t work, you cannot give a slot a default argument inside the \\cf1\\f1\\fs16 connect \\cf0\\f0\\fs17 statement. The \\cf1\\f1\\fs16 SLOT \\cf0\\f0\\fs17 macros actually just transforms its argument into a string and searches for the slots name in a list of registered slots for the \\cf1\\f1\\fs16 text \\cf0\\f0\\fs17 class.\\par\r\n\\par\r\nYou have to call your own slot that takes no arguments and calls \\cf1\\f1\\fs16 setPlainText \\cf0\\f0\\fs17 manually with the intended text. Perhaps Qt has some helper class in that direction, but your solution should not work.\\par\r\n\\par\r\nBy the way, have you actually tried this and got an error, or have you just posted it here without simply trying it out?\\par\r\n}\r\n'),
(59, 60, 4, '2011-06-05 16:11:30', '{\\rtf1\\ansi\\ansicpg1250\\deff0\\deflang1048{\\fonttbl{\\f0\\fnil\\fcharset238 Microsoft Sans Serif;}}\r\n\\viewkind4\\uc1\\pard\\f0\\fs17 Signal slot mechanism can be compared with (or boiled down to) function call. You are calling a function(slot) in a place where signal is emitted. Now imagine that the function expects some arguments and there is no default value. But you are trying to call the function. What will happen?. That''s what happening in your code.\\par\r\n}\r\n'),
(60, 62, 13, '2011-06-05 16:26:07', '{\\rtf1\\ansi\\ansicpg1250\\deff0\\deflang1048{\\fonttbl{\\f0\\fnil\\fcharset238 Microsoft Sans Serif;}{\\f1\\fnil\\fcharset0 Microsoft Sans Serif;}{\\f2\\fnil\\fcharset0 Courier New;}{\\f3\\fnil\\fcharset238 Verdana;}{\\f4\\fnil\\fcharset0 Verdana;}}\r\n{\\colortbl ;\\red169\\green169\\blue169;\\red255\\green165\\blue0;\\red0\\green0\\blue0;}\r\n\\viewkind4\\uc1\\pard\\f0\\fs17 You can encounter the problem of race condition\\lang1033\\f1 .\\lang1048\\f0\\par\r\nTo avoid this if you only need to append data you can use\\lang1033\\f1 .\\par\r\n\\par\r\n\\cf1\\f2\\fs16 file_put_contents\\cf2 (\\cf1 ,,FILE_APPEND|LOCK_EX\\cf2 )\\cf1 ;\\cf3\\f3\\par\r\n\\par\r\nand dont'' worry about your data integrity\\f4 .\\cf0\\lang1048\\f0\\fs17\\par\r\n}\r\n'),
(61, 63, 10, '2011-06-05 16:30:19', '{\\rtf1\\ansi\\ansicpg1250\\deff0\\deflang1048{\\fonttbl{\\f0\\fnil\\fcharset238 Microsoft Sans Serif;}{\\f1\\fnil\\fcharset238{\\*\\fname Courier New;}Courier New CE;}}\r\n{\\colortbl ;\\red169\\green169\\blue169;}\r\n\\viewkind4\\uc1\\pard\\f0\\fs17 It''s called \\cf1\\f1\\fs16 encapsulation \\cf0\\f0\\fs17 and it''s a very good thing. Encapsulation insulates your class from other classes mucking about with it''s internals, they only get the access that you allow through your methods. It also protects them from changes that you may make to the class internals. Without encapsulation if you make a change to a variable''s name or usage, that change propagates to all other classes that use the variable. If you force them to go through a method, there''s at least a chance that you''ll be able to handle the change in the method and protect the other classes from the change.\\par\r\n}\r\n'),
(62, 63, 11, '2011-06-05 16:31:05', '{\\rtf1\\ansi\\ansicpg1250\\deff0\\deflang1048{\\fonttbl{\\f0\\fnil\\fcharset238 Microsoft Sans Serif;}}\r\n\\viewkind4\\uc1\\pard\\f0\\fs17 The purpose of encapsulation is to hide the internals of an object from other objects. The idea is that the external footprint of the object constitutes it''s defined type, think of it like a contract with other objects. Internally, it may have to jump through some hoops to provide the outward-facing functionality, but that''s of no concern to other objects. They shouldn''t be able to mess with it.\\par\r\n\\par\r\nFor example, let''s say you have a class which provides calculations for sales tax. Some kind of utility service object, basically. It has a handful of methods which provide the necessary functionality.\\par\r\n\\par\r\nInternally, that class is hitting a database to get some values (tax for a given jurisdiction, for example) in order to perform the calculations. It may be maintaining a database connection and other database-related things internally, but other classes don''t need to know about that. Other classes are concerned only with the outward facing contract of functionality.\\par\r\n\\par\r\nSuppose sometime later the database needs to be replaced with an external web service. (The company is going with a service for calculating sales tax rather than maintain it internally.). Because the class is encapsulated, you can change its internal implementation to use the service instead of the database very easily. The class just needs to continue to provide the same outward facing functionality.\\par\r\n\\par\r\nIf other classes were mucking around with the internals of the class, then re-implementing it would risk breaking others parts of the system.\\par\r\n}\r\n'),
(63, 64, 8, '2011-06-05 16:35:07', '{\\rtf1\\ansi\\ansicpg1250\\deff0\\deflang1048{\\fonttbl{\\f0\\fnil\\fcharset238 Microsoft Sans Serif;}{\\f1\\fnil\\fcharset238{\\*\\fname Courier New;}Courier New CE;}}\r\n{\\colortbl ;\\red169\\green169\\blue169;}\r\n\\viewkind4\\uc1\\pard\\f0\\fs17 Objects based on \\cf1\\f1\\fs16 Resources \\cf0\\f0\\fs17 can''t be serialized.\\par\r\n\\par\r\nI guess I don''t have to explain why :)\\par\r\n}\r\n'),
(64, 65, 6, '2011-06-05 16:40:40', '{\\rtf1\\ansi\\ansicpg1250\\deff0\\deflang1048{\\fonttbl{\\f0\\fnil\\fcharset238 Microsoft Sans Serif;}{\\f1\\fnil\\fcharset238{\\*\\fname Courier New;}Courier New CE;}}\r\n{\\colortbl ;\\red255\\green0\\blue0;\\red169\\green169\\blue169;\\red0\\green0\\blue255;\\red255\\green165\\blue0;\\red255\\green192\\blue203;}\r\n\\viewkind4\\uc1\\pard\\f0\\fs17 file1:\\par\r\n\\cf1\\f1\\fs16 static\\cf2  \\cf3 int\\cf2  a;\\cf0\\f0\\fs17\\par\r\n\\par\r\nfile2:\\par\r\n\\cf2\\f1\\fs16 extern \\cf3 int\\cf2  a;\\cf0\\f0\\fs17\\par\r\n\\par\r\nThere are two variables referenced here. The first is a declaration and definition of a variable with internal linkage in file1; the second is a declaration only of a variable with external linkage in file2. This doesn''t necessarily cause an error; it is completely legal to have a variable with external linkage used in some translation units and identically named variables with internal linkage used by other translation units. Any link error would only occur if a is used in file2 and there isn''t a definition for this a in file2 or any other translation unit in the program.\\par\r\n\\par\r\n\\cf4\\f1\\fs16 #include \\cf5 "file1"\\cf2\\par\r\nextern \\cf3 int\\cf2  a;\\cf0\\par\r\n\\par\r\n\\f0\\fs17 In this example you have combined the two files into a single translation unit. The variable \\cf2\\f1\\fs16 a\\cf0\\f0\\fs17  is first declared and defined in \\cf2\\f1\\fs16 file \\cf0\\f0\\fs17 with internal linkage due to \\cf2\\f1\\fs16 static\\cf0\\f0\\fs17 , the second is just a re-declaration which doesn''t alter the previous linkage. The second declaration is redundant in this instance. If you are still compiling both files separately as well as including \\cf2\\f1\\fs16 file1 \\cf0\\f0\\fs17 from \\cf2\\f1\\fs16 file2 \\cf0\\f0\\fs17 then each translation unit (\\cf2\\f1\\fs16 file1 \\cf0\\f0\\fs17 and\\cf2\\f1\\fs16  file1 + file2\\cf0\\f0\\fs17 ) will have its own distinct variable called \\cf2\\f1\\fs16 a\\cf0\\f0\\fs17 .\\par\r\n\\par\r\nNote that if you had used\\cf2\\f1\\fs16  extern \\cf3 int\\cf2  a; \\cf0\\f0\\fs17 followed by \\cf1\\f1\\fs16 static\\cf2  \\cf3 int\\cf2  a; \\cf0\\f0\\fs17 then this would be a compile error as the first declaration would declare \\cf2\\f1\\fs16 a\\cf0\\f0\\fs17  to have external linkage if no previously declaration was visible and then the second declaration and definition would cause an error because the linkage implied by \\cf1\\f1\\fs16 static\\cf2  \\cf3 int\\cf2  a; \\cf0\\f0\\fs17 would conflict with the previous declaration.\\par\r\n}\r\n'),
(65, 66, 8, '2011-06-05 16:45:40', '{\\rtf1\\ansi\\ansicpg1250\\deff0\\deflang1048{\\fonttbl{\\f0\\fnil\\fcharset0 Microsoft Sans Serif;}{\\f1\\fnil\\fcharset238 Microsoft Sans Serif;}{\\f2\\fnil\\fcharset238{\\*\\fname Courier New;}Courier New CE;}}\r\n{\\colortbl ;\\red169\\green169\\blue169;}\r\n\\viewkind4\\uc1\\pard\\lang1033\\f0\\fs17 H\\lang1048\\f1 ere''s a really simple brute-force python solution that doesn''t require recursion: \\par\r\n\\cf1\\f2\\fs16\\par\r\nimport itertools\\par\r\nsum = 100\\par\r\na = 20\\par\r\nb = 5\\par\r\nc = 10\\par\r\na_range = range(0, sum + 1, a)\\par\r\nb_range = range(0, sum + 1, b)\\par\r\nc_range = range(0, sum + 1, c)\\par\r\nfor i, j, k in itertools.product(a_range, b_range, c_range):\\par\r\n    if i + j + k == 100:\\par\r\n        print i, '','', j, '','', k\\par\r\n\\cf0\\f1\\fs17\\par\r\nAlso, there are ways to compute the cartesian product of an arbitrary list of lists without recursion. (lol = list of lists)\\par\r\n\\par\r\n\\cf1\\f2\\fs16 def product_gen(*lol):\\par\r\n    indices = [0] * len(lol)\\par\r\n    index_limits = [len(l) - 1 for l in lol]\\par\r\n    index_accumulator = []\\par\r\n    while indices < index_limits:\\par\r\n        yield [l[i] for l, i in zip(lol, indices)]\\par\r\n        for n, index in enumerate(indices):\\par\r\n            index += 1\\par\r\n            if index > index_limits[n]:\\par\r\n                indices[n] = 0\\par\r\n            else:\\par\r\n                indices[n] = index\\par\r\n                break\\par\r\n    yield [l[i] for l, i in zip(lol, indices)]\\par\r\n\\cf0\\f1\\fs17\\par\r\nIf you''re just learning python, then you might not be familiar with the yield statement or the zip function; in that case, the below code will be clearer.\\par\r\n\\par\r\n\\cf1\\f2\\fs16 def product(*lol):\\par\r\n    indices = [0] * len(lol)\\par\r\n    index_limits = [len(l) - 1 for l in lol]\\par\r\n    index_accumulator = []\\par\r\n    while indices < index_limits:\\par\r\n        index_accumulator.append([lol[i][indices[i]] for i in range(len(lol))])\\par\r\n        for n, index in enumerate(indices):\\par\r\n            index += 1\\par\r\n            if index > index_limits[n]:\\par\r\n                indices[n] = 0\\par\r\n            else:\\par\r\n                indices[n] = index\\par\r\n                break\\par\r\n    return index_accumulator + [[lol[i][indices[i]] for i in range(len(lol))]]\\cf0\\f1\\fs17\\par\r\n\\par\r\nYou did a smart thing in your code by skipping those values for which i + j + k is greater than sum. None of these do that. But it''s possible to modify the second two to do that, with some loss of generality. \\par\r\n}\r\n'),
(66, 68, 15, '2011-06-05 16:52:05', '{\\rtf1\\ansi\\ansicpg1250\\deff0\\deflang1048{\\fonttbl{\\f0\\fnil\\fcharset238 Microsoft Sans Serif;}}\r\n\\viewkind4\\uc1\\pard\\f0\\fs17 Not sure if this fits your requirements, but:\\par\r\n\\par\r\n   1. Mergesort the set (this uses divide and conquer).\\par\r\n   2. Start with the first and last elements of the set, and compare their sum to x. If the sum is equal, you are done. If the sum is larger, step down to the second last element, if the sum is smaller, step up to the second element.\\par\r\n   3. Repeat step two, working in from the ends to the center of the sorted set, until the elements summing to x are found, or there are no more elements.\\par\r\n\\par\r\nThe divide and conquer sort is O(n lg n), the stepping through the sorted set is O(n), therefore total complexity O(n lg n).\\par\r\n\\par\r\nEd: sum to x, not M.\\par\r\n}\r\n'),
(67, 69, 9, '2011-06-05 16:59:19', '{\\rtf1\\ansi\\ansicpg1250\\deff0\\deflang1048{\\fonttbl{\\f0\\fnil\\fcharset238 Microsoft Sans Serif;}{\\f1\\fnil\\fcharset0 Microsoft Sans Serif;}}\r\n\\viewkind4\\uc1\\pard\\f0\\fs17 Whi\\lang1033\\f1 le\\lang1048\\f0  it depends on the linker being used. Object files are including in the final binary in their entirity. So, if you combine several object files into one object file, then the resulting (combined) object file is included in the resultant binary.\\par\r\n\\par\r\nIn contrast, a library is just that, a library of object files. The linker will only pull the object files from the library that it needs to resolve all the symbolic links. If an object file (in the library) is not needed, then it is not included int the binary.\\par\r\n}\r\n'),
(68, 70, 19, '2011-06-05 17:03:42', '{\\rtf1\\ansi\\ansicpg1250\\deff0\\deflang1048{\\fonttbl{\\f0\\fnil\\fcharset238 Microsoft Sans Serif;}{\\f1\\fnil\\fcharset238{\\*\\fname Courier New;}Courier New CE;}}\r\n{\\colortbl ;\\red169\\green169\\blue169;\\red255\\green165\\blue0;\\red255\\green0\\blue0;\\red255\\green192\\blue203;\\red0\\green128\\blue0;}\r\n\\viewkind4\\uc1\\pard\\f0\\fs17 Your bug is here:\\par\r\n\\par\r\nwhile ((ch = getchar()) == '' '')\\cf1\\f1\\fs16\\par\r\n\\cf2\\{\\cf1\\par\r\n    \\cf3 if\\cf1  \\cf2 (\\cf1 ch != \\cf4 '' ''\\cf2 )\\cf1\\par\r\n        printf\\cf2 (\\cf4 "%c"\\cf1 , ch\\cf2 )\\cf1 ;  \\cf5 //print the first letter of the last name\\cf1\\par\r\n\\cf2\\}\\cf1\\par\r\n\\cf3 while\\cf2 ((\\cf1 ch = getchar\\cf2 ())\\cf1  != \\cf4 '' ''\\cf1  && ch != \\cf4 ''\\\\n''\\cf2 )\\cf1\\par\r\n\\cf2\\{\\cf1\\par\r\n    printf\\cf2 (\\cf4 "%c"\\cf1 , ch\\cf2 )\\cf1 ;\\par\r\n\\cf2\\}\\cf0\\f0\\fs17\\par\r\n\\par\r\nThe first loop reads characters until it finds a non-space. That''s your ''T''. Then the second loop overwrites it with the next character, ''u'', and prints it. If you switch the second loop to a do \\{\\} while(); it should work.\\par\r\n}\r\n'),
(69, 71, 4, '2011-06-05 17:06:51', '{\\rtf1\\ansi\\ansicpg1250\\deff0\\deflang1048{\\fonttbl{\\f0\\fnil\\fcharset238 Microsoft Sans Serif;}}\r\n\\viewkind4\\uc1\\pard\\f0\\fs17 RETURN VALUE\\par\r\n       On success, the PID of the child process is returned in the parent, \\par\r\n       and 0 is returned in the child.  On failure, -1 is returned in the parent,\\par\r\n       no child process  is  created,  and  errno  is  set appropriately.\\par\r\n\\par\r\nSo, in the parent process, fork() returns the pid of the child process that was created.\\par\r\n}\r\n'),
(70, 71, 17, '2011-06-05 17:07:45', '{\\rtf1\\ansi\\ansicpg1250\\deff0\\deflang1048{\\fonttbl{\\f0\\fnil\\fcharset238 Microsoft Sans Serif;}{\\f1\\fnil\\fcharset0 Microsoft Sans Serif;}{\\f2\\fnil\\fcharset238{\\*\\fname Courier New;}Courier New CE;}}\r\n{\\colortbl ;\\red169\\green169\\blue169;}\r\n\\viewkind4\\uc1\\pard\\f0\\fs17 I won''t repeat \\lang1033\\f1 jones\\lang1048\\f0 ''s answer, as he''s entirely correct. But I''d point out that any program can retrieve it''s own PID with the \\cf1\\f2\\fs16 getpid \\cf0\\f0\\fs17 system call. So there''s no reason for the fork to return you own PID. Instead, you may want to know the PID of the process you just forked off, which may be difficult to obtain if it wasn''t returned (to the parent) by \\cf1\\f2\\fs16 fork\\cf0\\f0\\fs17 .\\par\r\n}\r\n'),
(71, 72, 14, '2011-06-05 18:15:25', '{\\rtf1\\ansi\\ansicpg1252\\deff0\\deflang1033{\\fonttbl{\\f0\\fnil\\fcharset0 Microsoft Sans Serif;}{\\f1\\fnil\\fcharset0 Courier New;}}\r\n{\\colortbl ;\\red169\\green169\\blue169;\\red255\\green0\\blue0;\\red255\\green165\\blue0;}\r\n\\viewkind4\\uc1\\pard\\f0\\fs17 You can write your own serialization and deserialization methods by overwriting:\\par\r\n\\par\r\n\\cf1\\f1\\fs16  \\cf2 private\\cf1  \\cf2 void\\cf1  writeObject\\cf3 (\\cf1 java.io.ObjectOutputStream out\\cf3 )\\cf1\\par\r\n     throws IOException\\par\r\n \\cf2 private\\cf1  \\cf2 void\\cf1  readObject\\cf3 (\\cf1 java.io.ObjectInputStream in\\cf3 )\\cf1\\par\r\n     throws IOException, ClassNotFoundException;\\cf0\\f0\\fs17\\par\r\n\\par\r\nwhich enables you to handle those cases yourself. You can still use the default methods by using out.defaultWriteObject/in.defaultReadObject to only have to handle the cases where data may be missing (or if you have default values for invalid objects, read all fields with the normal methods and then overwrite the invalid fields with the correct data).\\par\r\n}\r\n'),
(72, 72, 21, '2011-06-05 18:16:22', '{\\rtf1\\ansi\\ansicpg1252\\deff0\\deflang1033{\\fonttbl{\\f0\\fnil\\fcharset0 Microsoft Sans Serif;}}\r\n\\viewkind4\\uc1\\pard\\f0\\fs17 The first question that I would ask is if the code is throwing exceptions? If not, then inspect the object and set the properties/objects to a defaulted state since there is not way to retrieve the data if they did not send it. Or in the constructor of the objects, add initialization code so that the deserializer will have an initialized object to work with.\\par\r\n}\r\n'),
(73, 73, 21, '2011-06-05 18:21:22', '{\\rtf1\\ansi\\ansicpg1252\\deff0\\deflang1033{\\fonttbl{\\f0\\fnil\\fcharset0 Microsoft Sans Serif;}}\r\n\\viewkind4\\uc1\\pard\\f0\\fs17 Obviously, pointers aren''t my thing.\\par\r\n}\r\n'),
(74, 73, 5, '2011-06-05 18:23:48', '{\\rtf1\\ansi\\ansicpg1252\\deff0\\deflang1033{\\fonttbl{\\f0\\fnil\\fcharset0 Microsoft Sans Serif;}}\r\n\\viewkind4\\uc1\\pard\\f0\\fs17 Check out C++ dot com reference. You''ll find everything you need there. Good luck!\\par\r\n}\r\n'),
(75, 73, 21, '2011-06-05 18:24:48', '{\\rtf1\\ansi\\ansicpg1252\\deff0\\deflang1033{\\fonttbl{\\f0\\fnil\\fcharset0 Microsoft Sans Serif;}}\r\n\\viewkind4\\uc1\\pard\\f0\\fs17 Gee, thanks! Problem solved ;)\\par\r\n}\r\n'),
(76, 74, 3, '2011-06-05 20:26:28', '{\\rtf1\\ansi\\ansicpg1252\\deff0\\deflang1033{\\fonttbl{\\f0\\fnil\\fcharset0 Microsoft Sans Serif;}}\r\n\\viewkind4\\uc1\\pard\\f0\\fs17 First, while not wanting to generalize when it comes to performance problems, the issue you''re seeing are unlikely to be purely down to memory use, though if the lists are large this could come into play when they''re refreshed and a large number of objects become eligible for collection.\\par\r\n\\par\r\nTo solve issues relating to garbage collection there''s a few rules of thumb, but it always comes down to breaking out a profiler an tuning the garbage collector - there''s more on that here.\\par\r\n\\par\r\nBut before that any loading of a database is going to involve iteration over a result set, so the biggest optimization you can make will be to reduce the size of the result sets. There''s a couple of ways to do that:\\par\r\n\\par\r\n    if you using a map, try to use keys that don''t require loading and do the load when you get a miss.\\par\r\n    once loaded, only refresh the rows that have changed since you last loaded the data, though this obivously doesn''t solve the start-up problem.\\par\r\n\\par\r\nNow all that said, I would not recommend you write your own caching code in the first place. The reasons I say this are:\\par\r\n\\par\r\n    all modern RDBMS cache, so providing your queries are performant getting the actual result set should not be a bottleneck.\\par\r\n    Hibernate provides not only ORM but a robust and well understood caching solution.\\par\r\n    if you really need to cache massive datasets, use Coherence or similar - the cache can be started in a seperate JVM and your application doesn''t need to take the load hit.\\par\r\n}\r\n'),
(77, 74, 3, '2011-06-05 20:27:18', '{\\rtf1\\ansi\\ansicpg1252\\deff0\\deflang1033{\\fonttbl{\\f0\\fnil\\fcharset0 Microsoft Sans Serif;}{\\f1\\fnil\\fcharset0 Courier New;}}\r\n{\\colortbl ;\\red169\\green169\\blue169;\\red255\\green165\\blue0;}\r\n\\viewkind4\\uc1\\pard\\f0\\fs17 Be aware that invoking\\par\r\n\\par\r\n\\cf1\\f1\\fs16 System.gc\\cf2 ()\\cf0\\f0\\fs17\\par\r\n\\par\r\nor\\par\r\n\\cf1\\f1\\fs16\\par\r\nRuntime.getRuntime\\cf2 ()\\cf1 .gc\\cf2 ()\\cf0\\f0\\fs17\\par\r\n\\par\r\nis a bad idea unless you really need to do that. You should leave the VM the task of deciding when to free objects, unless after profiling you found that it''s the only way to make the application go faster on your client''s VM.\\par\r\n}\r\n'),
(78, 74, 3, '2011-06-05 20:27:54', '{\\rtf1\\ansi\\ansicpg1252\\deff0\\deflang1033{\\fonttbl{\\f0\\fnil\\fcharset0 Microsoft Sans Serif;}}\r\n\\viewkind4\\uc1\\pard\\f0\\fs17 I tend to use YourKit for this sort of thing. It costs money but IMO is worth every penny (no connection other than as a customer).\\par\r\n}\r\n'),
(79, 74, 6, '2011-06-05 20:28:43', '{\\rtf1\\ansi\\ansicpg1252\\deff0\\deflang1033{\\fonttbl{\\f0\\fnil\\fcharset0 Microsoft Sans Serif;}}\r\n\\viewkind4\\uc1\\pard\\f0\\fs17 You have two problems here: discovering how much memory is in use, and managing a cache. I''m not sure that the two are really closely related, although they may be.\\par\r\n\\par\r\nDiscovering how much memory an object uses isn''t extremely difficult: one excellent article you can use for reference is "Sizeof for Java" from JavaWorld. It escapes the whole garbage collection fiasco, which has a ton of holes in it (it''s slow, it doesn''t count the object but the heap - meaning that other objects factor into your results that you may not want, etc.)\\par\r\n\\par\r\nManaging the time to initialize the cache is another problem. I work for a company that has a data grid as a product, and thus I''m biased; be aware.\\par\r\n\\par\r\nOne option is not using a cache at all, but using a data grid. I work for GigaSpaces Technologies, and I feel ours is the best; we can load data from a database on startup, and hold your data there as a distributed, transactional data store in memory (so your greatest cost is network access.) We have a community edition as well as full-featured platforms, depending on your need and budget. (The community edition is free.) We support various protocols, including JDBC, JPA, JMS, Memcached, a Map API (similar to JCache), and a native API.\\par\r\n\\par\r\nOther similar options include Coherence, which is itself a data grid, and Terracotta DSO, which can distribute an object graph on a JVM heap.\\par\r\n\\par\r\nYou can also look at the cache projects themselves: Two include Ehcache and OSCache. (Again: bias. I was one of the people who started OpenSymphony, so I''ve a soft spot for OSCache.) In your case, what would happen is not a preload of cache - note that I don''t know your application, so I''m guessing and might be wrong - but a cache on demand. When you acquire data, you''d check the cache for data first and fetch from the DB only if the data is not in cache, and load the cache on read.\\par\r\n\\par\r\nOf course, you can also look at memcached, although I obviously prefer my employer''s offering here.\\par\r\n}\r\n'),
(80, 76, 10, '2011-06-05 20:53:02', '{\\rtf1\\ansi\\ansicpg1252\\deff0\\deflang1033{\\fonttbl{\\f0\\fnil\\fcharset0 Microsoft Sans Serif;}}\r\n\\viewkind4\\uc1\\pard\\f0\\fs17 The best test I found was a paper based test, eg, it didnt allow them to be reliant on IDE, google etc, but fundamental knowledge in their heads.\\par\r\n}\r\n'),
(81, 76, 7, '2011-06-05 20:53:39', '{\\rtf1\\ansi\\ansicpg1252\\deff0\\deflang1033{\\fonttbl{\\f0\\fnil\\fcharset0 Microsoft Sans Serif;}}\r\n\\viewkind4\\uc1\\pard\\f0\\fs17 thank you\\par\r\n}\r\n'),
(82, 76, 15, '2011-06-05 20:55:12', '{\\rtf1\\ansi\\ansicpg1252\\deff0\\deflang1033{\\fonttbl{\\f0\\fnil\\fcharset0 Microsoft Sans Serif;}}\r\n\\viewkind4\\uc1\\pard\\f0\\fs17 good link\\par\r\n}\r\n'),
(83, 77, 12, '2011-06-05 21:01:57', '{\\rtf1\\ansi\\ansicpg1252\\deff0\\deflang1033{\\fonttbl{\\f0\\fnil\\fcharset0 Microsoft Sans Serif;}}\r\n\\viewkind4\\uc1\\pard\\f0\\fs17 There are two things you need to be very mindful of:\\par\r\n\\par\r\n    Endianness. If the endianness of your client and server every diverge you''ll be in a situation where you can''t communicate. Given today''s heavy emphasis on x86 systems, you might convince yourself to feel comfortable with this limitation. If I were you, I would at a minimum, build in a validation. For example, at the beginning of every communication session send a known checksum, 0xdeadbeef for example. This would allow you to assert that the endianness between the client and server is the same, hopefully avoiding the continuation of the session and all kinds of potential bugs.\\par\r\n\\par\r\n    Word Size. This is the more insidious and stronger reason why you should not do what you''re thinking of doing. Unless you can strongly assert that the word size of the sender and receiver will never differ then your method is fraught with peril. Consider you have a struct as follows:\\par\r\n\\par\r\n    struct some_msg \\{ long payload; \\};\\par\r\n\\par\r\n    What happens when a 32-bit gcc/linux system sends that message to a gcc/linux 64-bit system? Well, on the 32-bit system it will happily send out 4 bytes of data. However, the 64-bit system will overlay the struct onto 8 bytes of data. Bad news bears.\\par\r\n\\par\r\nWhile it might be unlikely that you''ll switch from x86 to say, sparc, it is almost a given that over time your systems will be 64-bit. Whether you have legacy 32-bit systems is unknown to me, but without very tight control over both client and server its almost guaranteed that you''ll have a mixed word size environment.\\par\r\n\\par\r\nI''m sure it can be made to work if you very specifically define and control the platforms being used. Further, you might limit your risk by using the fixed sized typedefs such as int32_t and uint64_t. You are playing with fire, IMO, if you do this. Any conceivable advantage is quickly reduced by the high level of lock-in your designing into your system.\\par\r\n}\r\n'),
(84, 77, 11, '2011-06-05 21:03:02', '{\\rtf1\\ansi\\ansicpg1252\\deff0\\deflang1033{\\fonttbl{\\f0\\fnil\\fcharset0 Microsoft Sans Serif;}}\r\n\\viewkind4\\uc1\\pard\\f0\\fs17 This is perfectly possible. Not recommended, though, because now you''re using the same environment for the client and the server, but you may change in the future, and you''ll have to change this code to be more platform/implementation independent.\\par\r\n\\par\r\nOptions? boost::serialization, XML-RPC, even HTTP/REST or any other high-level protocol that suits you, Google Protocol Buffers, CORBA, etc.\\par\r\n}\r\n'),
(85, 77, 15, '2011-06-05 21:03:36', '{\\rtf1\\ansi\\ansicpg1252\\deff0\\deflang1033{\\fonttbl{\\f0\\fnil\\fcharset0 Microsoft Sans Serif;}}\r\n\\viewkind4\\uc1\\pard\\f0\\fs17 Gee, thanks.\\par\r\n}\r\n'),
(86, 75, 15, '2011-06-05 21:04:32', '{\\rtf1\\ansi\\ansicpg1252\\deff0\\deflang1033{\\fonttbl{\\f0\\fnil\\fcharset0 Microsoft Sans Serif;}}\r\n\\viewkind4\\uc1\\pard\\f0\\fs17 Check out the Java OOP concepts ref.\\par\r\n}\r\n');

-- --------------------------------------------------------

--
-- Table structure for table `question`
--

CREATE TABLE IF NOT EXISTS `question` (
  `id_question` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `owner_user` int(10) unsigned NOT NULL,
  `timestamp_question` datetime NOT NULL,
  `title_question` varchar(200) NOT NULL,
  `content_question` varchar(10000) NOT NULL,
  `status_question` tinyint(1) NOT NULL,
  PRIMARY KEY (`id_question`),
  KEY `fk_question_owner` (`owner_user`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=78 ;

--
-- Dumping data for table `question`
--

INSERT INTO `question` (`id_question`, `owner_user`, `timestamp_question`, `title_question`, `content_question`, `status_question`) VALUES
(60, 3, '2011-06-05 16:04:12', 'Add text to QTextEdit using QPushButton', '{\\rtf1\\ansi\\ansicpg1250\\deff0\\deflang1048{\\fonttbl{\\f0\\fnil\\fcharset238 Verdana;}{\\f1\\fnil\\fcharset238{\\*\\fname Courier New;}Courier New CE;}{\\f2\\fnil\\fcharset0 Verdana;}}\r\n{\\colortbl ;\\red255\\green165\\blue0;\\red169\\green169\\blue169;\\red0\\green0\\blue255;\\red255\\green0\\blue0;\\red255\\green192\\blue203;\\red128\\green0\\blue128;}\r\n\\viewkind4\\uc1\\pard\\f0\\fs17 Just a simple program to add text to textedit when button is clicked... anything wrong here??\\par\r\n\\par\r\n\\cf1\\f1\\fs16 #include&ltQPushButton>\\cf2\\par\r\n\\cf1 #include&ltQApplication>\\cf2\\par\r\n\\cf1 #include&ltQTextEdit>\\cf2\\par\r\n\\cf1 #include&ltQWidget>\\cf2\\par\r\n\\cf1 #include&ltQHBoxLayout>\\cf2\\par\r\n\\cf1 #include&ltQLabel>\\cf2\\par\r\n\\par\r\n\\cf3 int\\cf2  main\\cf1 (\\cf3 int\\cf2  argc,\\cf3 char\\cf2  *argv\\cf1 [])\\cf2\\par\r\n\\cf1\\{\\cf2\\par\r\nQApplication app\\cf1 (\\cf2 argc,argv\\cf1 )\\cf2 ;\\par\r\nQHBoxLayout *layout=\\cf4 new\\cf2  QHBoxLayout;\\par\r\nQTextEdit *text = \\cf4 new\\cf2  QTextEdit\\cf1 ()\\cf2 ; \\par\r\nQWidget window;\\par\r\nQPushButton *button;\\par\r\n\\par\r\nlayout-\\cf1 >\\cf2 addWidget\\cf1 (\\cf2 text\\cf1 )\\cf2 ;\\par\r\nbutton = \\cf4 new\\cf2  QPushButton\\cf1 ()\\cf2 ;\\par\r\nbutton-\\cf1 >\\cf2 setText\\cf1 (\\cf2 QChar\\cf1 (\\cf2 i+48\\cf1 ))\\cf2 ;\\par\r\n\\par\r\nQObject::connect\\cf1 (\\cf2 button,SIGNAL\\cf1 (\\cf2 clicked\\cf1 ())\\cf2 ,text,SLOT\\cf1 (\\cf2 setPlainText\\cf1 (\\cf5 "hai"\\cf1 )))\\cf2 ;\\par\r\n\\par\r\nlayout-\\cf1 >\\cf2 addWidget\\cf1 (\\cf2 button\\cf1 )\\cf2 ;\\par\r\nwindow.setLayout\\cf1 (\\cf2 layout\\cf1 )\\cf2 ;\\par\r\nwindow.resize\\cf1 (\\cf2 500, 500\\cf1 )\\cf2 ;\\par\r\nwindow.show\\cf1 ()\\cf2 ;\\par\r\n\\par\r\n\\cf6 return\\cf2  app.exec\\cf1 ()\\cf2 ;\\par\r\n\\cf1\\}\\cf2\\par\r\n\\cf0\\f0\\fs17\\par\r\n\\lang1033\\f2 Thanks.\\lang1048\\f0\\par\r\n}\r\n', 0),
(61, 14, '2011-06-05 16:20:46', 'Make main() “uncrashable”', '{\\rtf1\\ansi\\ansicpg1250\\deff0\\deflang1048{\\fonttbl{\\f0\\fnil\\fcharset238 Verdana;}{\\f1\\fnil\\fcharset238{\\*\\fname Courier New;}Courier New CE;}{\\f2\\fnil\\fcharset0 Verdana;}{\\f3\\fnil\\fcharset0 Courier New;}}\r\n{\\colortbl ;\\red255\\green0\\blue0;\\red169\\green169\\blue169;\\red255\\green165\\blue0;\\red0\\green128\\blue0;\\red0\\green0\\blue255;\\red255\\green192\\blue203;\\red0\\green0\\blue0;\\red128\\green0\\blue128;}\r\n\\viewkind4\\uc1\\pard\\f0\\fs17 Hi!\\par\r\n\\par\r\nI want to program a daemon-manager that takes care that all daemons are running, like so (simplified pseudocode):\\par\r\n\\par\r\n\\cf1\\f1\\fs16 void\\cf2  watchMe\\cf3 (\\cf2 filename\\cf3 )\\cf2\\par\r\n\\cf3\\{\\cf2\\par\r\n    \\cf1 while\\cf2  \\cf3 (\\cf1 true\\cf3 )\\cf2\\par\r\n    \\cf3\\{\\cf2\\par\r\n        system\\cf3 (\\cf2 filename\\cf3 )\\cf2 ; \\cf4 //freezes as long as filename runs\\cf2\\par\r\n        \\cf4 //oh, filename must be crashed. Nevermind, will be restarted            \\cf2\\par\r\n    \\cf3\\}\\cf2\\par\r\n\\cf3\\}\\cf2        \\par\r\n\\par\r\n\\cf5 int\\cf2  main\\cf3 ()\\cf2\\par\r\n\\cf3\\{\\cf2\\par\r\n    _beginThread\\cf3 (\\cf2 watchMe, \\cf6 "foo.exe"\\cf3 )\\cf2 ;\\par\r\n    _beginThread\\cf3 (\\cf2 watchMe, \\cf6 "bar.exe"\\cf3 )\\cf2 ;\\par\r\n\\cf3\\}\\cf7\\f0\\par\r\n\\par\r\n\\lang1033\\f2 This part is already working - but now I am facing the problem that when an observed application - say foo.exe - crashes, the corresponding system-call freezes.\\par\r\n\\par\r\nThis makes the daemon useless.\\par\r\n\\par\r\nWhat I think might be a solution is to make the main() of the observed programs (which I control) "uncrashable" so they are shutting down gracefully without showing this ugly message box.\\par\r\n\\par\r\nLike so:\\par\r\n\\par\r\n\\cf1\\f3 try\\cf2\\par\r\n\\cf3\\{\\cf2\\par\r\n    \\cf5 char\\cf2  *p = NULL;\\par\r\n    *p = 123; \\cf4 //nice null pointer exception\\cf2\\par\r\n\\cf3\\}\\cf2\\par\r\n\\cf1 catch\\cf2  \\cf3 (\\cf2 ...\\cf3 )\\cf2\\par\r\n\\cf3\\{\\cf2\\par\r\n    cout \\cf3 <<\\cf2  \\cf6 "Caught Exception. Terminating gracefully"\\cf2  \\cf3 <<\\cf2  endl;\\par\r\n    \\cf8 return\\cf2  0;\\par\r\n\\cf3\\}\\cf7\\f0\\par\r\n\\par\r\nBut this doesn''t work as it still produces \\f2 an\\f0  error message\\f2 .\\par\r\nAny help would be highly appreciated.\\par\r\n\\par\r\nGreets\\lang1048\\f0\\fs17\\par\r\n}\r\n', 0),
(62, 9, '2011-06-05 16:24:53', 'concurent file read/write - PHP', '{\\rtf1\\ansi\\ansicpg1250\\deff0\\deflang1048{\\fonttbl{\\f0\\fnil\\fcharset0 Verdana;}{\\f1\\fnil\\fcharset238 Verdana;}}\r\n\\viewkind4\\uc1\\pard\\lang1033\\f0\\fs17 W\\lang1048\\f1 hat happens when many request is received to read & write to a file [PHP] ?\\par\r\nDo the requests gets queued ?\\par\r\nor only one is accepted and remaining are thrown away ?\\par\r\n}\r\n', 0),
(63, 7, '2011-06-05 16:28:27', 'The advantage / disadvantage of private variables', '{\\rtf1\\ansi\\ansicpg1250\\deff0\\deflang1048{\\fonttbl{\\f0\\fnil\\fcharset238 Verdana;}{\\f1\\fnil\\fcharset238{\\*\\fname Courier New;}Courier New CE;}}\r\n{\\colortbl ;\\red0\\green0\\blue255;\\red169\\green169\\blue169;\\red255\\green165\\blue0;\\red255\\green0\\blue0;}\r\n\\viewkind4\\uc1\\pard\\f0\\fs17 Hi\\par\r\n\\par\r\nI''m used to make pretty much all of my class variables private and create "wrapper" functions that get / set them:\\par\r\n\\par\r\n\\cf1\\f1\\fs16 class\\cf2  Something\\cf3\\{\\cf2\\par\r\n  \\cf4 private\\cf2  $var;\\par\r\n\\par\r\n  function getVar\\cf3 ()\\{\\cf2\\par\r\n    $return $this-\\cf3 >\\cf2 var;\\par\r\n  \\cf3\\}\\cf2\\par\r\n\\par\r\n\\cf3\\}\\cf2\\par\r\n\\par\r\n$smth = \\cf4 new\\cf2  Something\\cf3 ()\\cf2 ;\\par\r\necho $smth-\\cf3 >\\cf2 getVar\\cf3 ()\\cf2 ;\\par\r\n\\cf0\\f0\\fs17\\par\r\nI see that a lot of people do this, so I ended up doing the same :)\\par\r\nIs there any advantage using them this way versus:\\par\r\n\\par\r\n\\cf1\\f1\\fs16 class\\cf2  Something\\cf3\\{\\cf2\\par\r\n  \\cf4 public\\cf2  $var;\\par\r\n\\cf3\\}\\cf2\\par\r\n$smth = \\cf4 new\\cf2  Something\\cf3 ()\\cf2 ;\\par\r\nechp $smth-\\cf3 >\\cf2 var;\\par\r\n\\cf0\\f0\\fs17\\par\r\nI know that private means that you can''t access them directly outside the class, but for me it doesn''t seem very important if the variable is accessible from anywhere...\\par\r\n\\par\r\nSo is there any other hidden advantage that I missing with private variables?\\par\r\n}\r\n', 0),
(64, 4, '2011-06-05 16:34:20', 'Why ''Serialization of ''SplFileInfo'' is not allowed ?', '{\\rtf1\\ansi\\ansicpg1250\\deff0\\deflang1048{\\fonttbl{\\f0\\fnil\\fcharset238 Verdana;}{\\f1\\fnil\\fcharset238{\\*\\fname Courier New;}Courier New CE;}}\r\n{\\colortbl ;\\red169\\green169\\blue169;\\red255\\green192\\blue203;}\r\n\\viewkind4\\uc1\\pard\\f0\\fs17 I''m trying to store an array of \\cf1\\f1\\fs16 SplFileInfo \\cf0\\f0\\fs17 instances in a cache with \\cf1\\f1\\fs16 serialize \\cf0\\f0\\fs17 command but the command throws this exception:\\par\r\n\\par\r\n\\cf1\\f1\\fs16 Exception\\cf2 '' with message ''\\cf1 Serialization of \\cf2 ''SplFileInfo''\\cf1  is not allowed\\cf0\\f0\\fs17\\par\r\n\\par\r\nWhy is it not allowed?\\par\r\nThanks!\\par\r\n\\par\r\nNote: I''m just curious. The problem itself can be workarounded.\\par\r\n}\r\n', 0),
(65, 17, '2011-06-05 16:37:28', 'Static member variable file scope', '{\\rtf1\\ansi\\ansicpg1250\\deff0\\deflang1048{\\fonttbl{\\f0\\fnil\\fcharset238 Verdana;}{\\f1\\fnil\\fcharset238{\\*\\fname Courier New;}Courier New CE;}}\r\n{\\colortbl ;\\red255\\green0\\blue0;\\red169\\green169\\blue169;\\red0\\green0\\blue255;\\red255\\green165\\blue0;\\red255\\green192\\blue203;}\r\n\\viewkind4\\uc1\\pard\\f0\\fs17 Static variable has the scope inside that file only where they are been declared, as shown in below code:\\par\r\n\\par\r\nfile1-\\par\r\n\\cf1\\f1\\fs16 static\\cf2  \\cf3 int\\cf2  a;\\cf0\\f0\\fs17\\par\r\n\\par\r\nfile2-\\par\r\n\\cf2\\f1\\fs16 extern \\cf3 int\\cf2  a;\\cf0\\f0\\fs17\\par\r\n\\par\r\nThis will give linking error as static variable a has the scope in file1 only. But I am confused with below code:\\par\r\n\\par\r\nfile2-\\par\r\n\\cf4\\f1\\fs16 #include \\cf5 "file1"\\cf2\\par\r\nextern \\cf3 int\\cf2  a;\\par\r\n\\cf0\\par\r\n\\f0\\fs17 Here it would not give any linking error. Then it means compiler is refering "a" which is declared in file1. But when you debug you will find address of variable "a" is different in file1 and file2. Is the compiler creating a another global variable "a" in file2?\\par\r\n}\r\n', 0),
(66, 16, '2011-06-05 16:44:00', 'How can I program a large number of for loops ?', '{\\rtf1\\ansi\\ansicpg1250\\deff0\\deflang1048{\\fonttbl{\\f0\\fnil\\fcharset238 Verdana;}{\\f1\\fnil\\fcharset238{\\*\\fname Courier New;}Courier New CE;}}\r\n{\\colortbl ;\\red0\\green0\\blue255;\\red169\\green169\\blue169;\\red255\\green165\\blue0;\\red255\\green0\\blue0;\\red255\\green192\\blue203;}\r\n\\viewkind4\\uc1\\pard\\f0\\fs17 Hi Everyone. I''m new to programming so I''m sorry in phrasing if I''m not asking this question correctly.\\par\r\n\\par\r\nI have the following code:\\par\r\n\\par\r\n\\cf1\\f1\\fs16 int\\cf2  sum = 100;\\par\r\n\\cf1 int\\cf2  a1 = 20;\\par\r\n\\cf1 int\\cf2  a2 = 5;\\par\r\n\\cf1 int\\cf2  a3 = 10;\\par\r\nfor \\cf3 (\\cf1 int\\cf2  i = 0; i * a1 \\cf3 <\\cf2 = sum; i++\\cf3 )\\cf2  \\cf3\\{\\cf2\\par\r\n    for \\cf3 (\\cf1 int\\cf2  j = 0; i * a1 + j * a2 \\cf3 <\\cf2 = sum; j++\\cf3 )\\cf2  \\cf3\\{\\cf2\\par\r\n        for \\cf3 (\\cf1 int\\cf2  k = 0; i * a1 + j * a2 + k * a3 \\cf3 <\\cf2 = sum; k++\\cf3 )\\cf2  \\cf3\\{\\cf2\\par\r\n            \\cf4 if\\cf2  \\cf3 (\\cf2 i * a1 + j * a2 + k * a3 == sum\\cf3 )\\cf2  \\cf3\\{\\cf2\\par\r\n                System.out.println\\cf3 (\\cf2 i + \\cf5 ","\\cf2  + j + \\cf5 ","\\cf2  + k\\cf3 )\\cf2 ;\\par\r\n            \\cf3\\}\\cf2\\par\r\n        \\cf3\\}\\cf2\\par\r\n    \\cf3\\}\\cf2    \\par\r\n\\cf3\\}\\cf0\\f0\\fs17\\par\r\n\\par\r\nbasically what it does is tell me the different combinations of a1, a2, and a3 that equal the above sum (in this case 100). This works fine but I''m trying to apply it to a larger dataset now and I''m not sure how to do without manually programming the for loops or knowing in advanced how many variables I''ll have(could be anywhere from 10 to 6000). I basically have a sql query that loads that data from an array.\\par\r\n\\par\r\nIs there a way in Java OR python (I''m learning both) to automatically create nested for and if loops?\\par\r\n\\par\r\nThanks so much in advance.\\par\r\n}\r\n', 0),
(67, 8, '2011-06-05 16:48:15', 'Can I represent a Red-black tree as binary leaf tree ?', '{\\rtf1\\ansi\\ansicpg1250\\deff0\\deflang1048{\\fonttbl{\\f0\\fnil\\fcharset238 Verdana;}{\\f1\\fnil\\fcharset238{\\*\\fname Courier New;}Courier New CE;}}\r\n{\\colortbl ;\\red169\\green169\\blue169;}\r\n\\viewkind4\\uc1\\pard\\f0\\fs17 Hi, I''ve been playing around with RB tree implementation in Haskell but having difficulty changing it a bit so the data is only placed in the leaves, like in a binary leaf tree:\\par\r\n\\par\r\n\\cf1\\f1\\fs16     /+\\\\\\par\r\n   /   \\\\\\par\r\n /+\\\\    \\\\\\par\r\n/   \\\\    c\\par\r\na   b\\cf0\\f0\\fs17\\par\r\n\\par\r\nThe internal nodes would hold other information e.g. size of tree, in addition to the color of the node (like in a normal RB tree but the data is held in the leaves ony). I am also not needed to sort the data being inserted. I use RB only to get a balanced tree as i insert data but I want to keep the order in which data is inserted.\\par\r\n\\par\r\nThe original code was (from Okasaki book):\\par\r\n\\par\r\n\\cf1\\f1\\fs16 data Color = R | B\\par\r\ndata Tree a = E | T Color (Tree a ) a (Tree a)\\par\r\n\\cf0\\f0\\fs17\\par\r\n\\cf1\\f1\\fs16 insert :: Ord a => a -> Tree a -> Tree a\\par\r\ninsert x s = makeBlack (ins s)\\par\r\n    where ins E = T R E x E\\par\r\n        ins (T color a y b) \\par\r\n            | x < y = balance color (ins a) y b\\par\r\n            | x == y = T color a y b\\par\r\n            | x > y = balance color a y (ins b)\\par\r\n        makeBlack (T _ a y b) = T B a y b\\cf0\\f0\\fs17\\par\r\n\\par\r\nI changed it to: (causing Exception:Non-exhaustive patterns in function ins)\\par\r\n\\par\r\n\\cf1\\f1\\fs16 data Color = R | B deriving Show\\par\r\ndata Tree a = E | Leaf a | T Color Int (Tree a) (Tree a)\\cf0\\f0\\fs17\\par\r\n\\par\r\n\\cf1\\f1\\fs16 insert :: Ord a => a -> Set a -> Set a\\par\r\ninsert x s = makeBlack (ins s)\\par\r\n    where \\par\r\n        ins E = T R 1 (Leaf x) E\\par\r\n        ins (T _ 1 a E) = T R 2 (Leaf x) a\\par\r\n        ins (T color y a b)\\par\r\n            | 0 < y = balance color y (ins a) b\\par\r\n            | 0 == y = T color y a b\\par\r\n            | 0 > y = balance color y a (ins b)\\par\r\n        makeBlack (T _ y a b) = T B y a b\\cf0\\f0\\fs17\\par\r\n\\par\r\nThe original balance function is:\\par\r\n\\par\r\n\\cf1\\f1\\fs16 balance B (T R (T R a x b) y c) z d = T R (T B a x b) y (T B c z d)\\par\r\nbalance B (T R a x (T R b y c)) z d = T R (T B a x b) y (T B c z d)\\par\r\nbalance B a x (T R (T R b y c) z d) = T R (T B a x b) y (T B c z d)\\par\r\nbalance B a x (T R b y (T R c z d)) = T R (T B a x b) y (T B c z d)\\par\r\nbalance color a x b = T color a x b\\cf0\\f0\\fs17\\par\r\n\\par\r\nwhich i changed a bit as is obvious from my code above.\\par\r\n\\par\r\nThanks in advance for help :)\\par\r\n}\r\n', 0),
(68, 10, '2011-06-05 16:51:15', 'Divide et impera problem', '{\\rtf1\\ansi\\ansicpg1250\\deff0\\deflang1048{\\fonttbl{\\f0\\fnil\\fcharset238 Verdana;}}\r\n\\viewkind4\\uc1\\pard\\f0\\fs17 Given a set M, find if there is a pair of numbers (a,b), both belong to M, and a+b=x, where x is a previously specified parameter. The problem should be solved using Divide et Impera in O(n * log n). Probably the problem should be split in two half-sized subproblems and then recombine the results in O(n).\\par\r\n\\par\r\nI would like a pseudocode for the given problem or a tip for solving it.\\par\r\n}\r\n', 0),
(69, 15, '2011-06-05 16:56:47', 'Advantages of libraries over combined object files.', '{\\rtf1\\ansi\\ansicpg1250\\deff0\\deflang1048{\\fonttbl{\\f0\\fnil\\fcharset238 Verdana;}}\r\n\\viewkind4\\uc1\\pard\\f0\\fs17 While it is commonplace to combine multiple object files in a library, it is possible (at least in Linux) to combine multiple object files into another object file.\\par\r\n\\par\r\nAs there are downsides to using libraries instead of just combined object files:\\par\r\n\\par\r\n1: It''s easier to work with only one type of file (object) when linking, especially if all files do the same thing.\\par\r\n\\par\r\n2: When linking (At least in GCC), libraries (by default) need to be ordered and can''t handle cyclic dependencies.\\par\r\n\\par\r\nI want to know what advantages there are to libraries (apart from the catch 22 that they''re used lots).\\par\r\n\\par\r\nAfter searching for a while, the only explanation I get seems to be that single libraries are better than multiple object files.\\par\r\n}\r\n', 0),
(70, 18, '2011-06-05 17:01:20', 'Problem with getchar in C', '{\\rtf1\\ansi\\ansicpg1250\\deff0\\deflang1048{\\fonttbl{\\f0\\fnil\\fcharset238 Verdana;}{\\f1\\fnil\\fcharset238{\\*\\fname Courier New;}Courier New CE;}}\r\n{\\colortbl ;\\red255\\green165\\blue0;\\red169\\green169\\blue169;\\red0\\green0\\blue255;\\red255\\green0\\blue0;\\red0\\green128\\blue0;\\red255\\green192\\blue203;\\red128\\green0\\blue128;}\r\n\\viewkind4\\uc1\\pard\\f0\\fs17 I want to write a program which can: when I enter, say "Alan Turing", it outputs "Turing, A". But for my following program, it outputs "uring, A", I thought for long but failed to figure out where T goes. Here is the code:\\par\r\n\\par\r\n\\cf1\\f1\\fs16 #include <stdio.h>\\cf2\\par\r\n\\cf3 int\\cf2  main\\cf1 (\\cf4 void\\cf1 )\\cf2\\par\r\n\\cf1\\{\\cf2\\par\r\n\\cf3 char\\cf2  initial, ch;\\par\r\n\\par\r\n\\cf5 //This program allows extra spaces before the first name and between first name and second name, and after the second name.\\cf2\\par\r\n\\par\r\nprintf\\cf1 (\\cf6 "enter name: "\\cf1 )\\cf2 ;\\par\r\n\\par\r\n\\cf4 while\\cf1 ((\\cf2 initial = getchar\\cf1 ())\\cf2  == \\cf6 '' ''\\cf1 )\\cf2\\par\r\n    ;\\par\r\n\\par\r\n\\cf4 while\\cf1 ((\\cf2 ch = getchar\\cf1 ())\\cf2  != \\cf6 '' ''\\cf1 )\\cf2   \\cf5 //skip first name\\cf2\\par\r\n    ;\\par\r\n\\par\r\n\\cf4 while\\cf2  \\cf1 ((\\cf2 ch = getchar\\cf1 ())\\cf2  == \\cf6 '' ''\\cf1 )\\cf2\\par\r\n\\cf1\\{\\cf2\\par\r\n    \\cf4 if\\cf2  \\cf1 (\\cf2 ch != \\cf6 '' ''\\cf1 )\\cf2\\par\r\n        printf\\cf1 (\\cf6 "%c"\\cf2 , ch\\cf1 )\\cf2 ;  \\cf5 //print the first letter of the last name\\cf2\\par\r\n\\cf1\\}\\cf2\\par\r\n\\cf4 while\\cf1 ((\\cf2 ch = getchar\\cf1 ())\\cf2  != \\cf6 '' ''\\cf2  && ch != \\cf6 ''\\\\n''\\cf1 )\\cf2\\par\r\n\\cf1\\{\\cf2\\par\r\n    printf\\cf1 (\\cf6 "%c"\\cf2 , ch\\cf1 )\\cf2 ;\\par\r\n\\cf1\\}\\cf2\\par\r\nprintf\\cf1 (\\cf6 ", %c.\\\\n"\\cf2 , initial\\cf1 )\\cf2 ;\\par\r\n\\par\r\n\\cf7 return\\cf2  0;\\par\r\n\\cf1\\}\\cf0\\f0\\fs17\\par\r\n}\r\n', 0),
(71, 19, '2011-06-05 17:06:02', 'Fork() and pid', '{\\rtf1\\ansi\\ansicpg1250\\deff0\\deflang1048{\\fonttbl{\\f0\\fnil\\fcharset238 Verdana;}{\\f1\\fnil\\fcharset238{\\*\\fname Courier New;}Courier New CE;}}\r\n{\\colortbl ;\\red0\\green0\\blue255;\\red169\\green169\\blue169;\\red255\\green165\\blue0;\\red255\\green0\\blue0;\\red255\\green192\\blue203;}\r\n\\viewkind4\\uc1\\pard\\f0\\fs17 The code:\\par\r\n\\par\r\n\\cf1\\f1\\fs16 int\\cf2  main\\cf3 (\\cf4 void\\cf3 )\\cf2  \\par\r\n\\cf3\\{\\cf2\\par\r\n    printf\\cf3 (\\cf5 "pid: %d\\\\n"\\cf2 , getpid\\cf3 ())\\cf2 ;\\par\r\n    pid = fork\\cf3 ()\\cf2 ;\\par\r\n\\par\r\n\\par\r\n    \\cf4 if\\cf2  \\cf3 (\\cf2 pid \\cf3 <\\cf2  0\\cf3 )\\cf2  \\cf3\\{\\cf2\\par\r\n        fprintf\\cf3 (\\cf2 stderr, \\cf5 "Fork Failed!"\\cf3 )\\cf2 ;\\par\r\n        exit\\cf3 (\\cf2 -1\\cf3 )\\cf2 ;\\par\r\n    \\cf3\\}\\cf2  \\cf4 else\\cf2  \\cf4 if\\cf2  \\cf3 (\\cf2 pid == 0\\cf3 )\\cf2  \\cf3\\{\\cf2\\par\r\n        execv\\cf3 (\\cf5 "sum"\\cf2 , argv\\cf3 )\\cf2 ;\\par\r\n    \\cf3\\}\\cf2  \\cf4 else\\cf2  \\cf3\\{\\cf2\\par\r\n        printf\\cf3 (\\cf5 "  pid: %d\\\\n"\\cf2 , pid\\cf3 )\\cf2 ;\\par\r\n        wait\\cf3 (\\cf2 NULL\\cf3 )\\cf2 ;\\par\r\n    \\cf3\\}\\cf2\\par\r\n\\cf3\\}\\cf0\\f0\\fs17\\par\r\n\\par\r\nThe output:\\par\r\n\\par\r\n\\cf2\\f1\\fs16 pid: 280\\par\r\npid: 281\\cf0\\f0\\fs17\\par\r\n\\par\r\nThe question:\\par\r\n\\par\r\nWhy are the two pid''s different. I thought they should be the same because the parent is what is executing in the else block and the parent is what is executing before the fork so they should be the same, no?\\par\r\n}\r\n', 1),
(72, 19, '2011-06-05 18:13:53', 'How deserialize, if lack of some date?', '{\\rtf1\\ansi\\ansicpg1252\\deff0\\deflang1033{\\fonttbl{\\f0\\fnil\\fcharset0 Verdana;}{\\f1\\fnil\\fcharset0 Courier New;}}\r\n{\\colortbl ;\\red255\\green165\\blue0;\\red169\\green169\\blue169;\\red255\\green192\\blue203;\\red255\\green0\\blue0;\\red128\\green0\\blue128;}\r\n\\viewkind4\\uc1\\pard\\f0\\fs17 We have two systems: external and internal, which are sharing information in JSON format (GSON library).\\par\r\n\\par\r\nInformation from an external system comes in internal and processed here.\\par\r\n\\par\r\nEverything was very good, coming from an external system data in JSON format in the internal system data deserialize and processed. For example:\\par\r\n\\par\r\ncome string:\\par\r\n\\par\r\n\\cf1\\f1\\fs16\\{\\cf2 UserLogInEvent:\\cf1\\{\\cf2 userName:\\cf3 ''Name''\\cf2 , time:\\cf3 ''00.00.00''\\cf1\\}\\}\\cf2\\par\r\n\\cf0\\f0\\fs17\\par\r\nthis string deserialize in object of this class:\\par\r\n\\par\r\n\\cf2\\f1\\fs16 UserLogInEvent implement Event \\cf1\\{\\cf2\\par\r\n\\par\r\n\\cf4 private\\cf2   String userName;\\par\r\n\\cf4 private\\cf2  Date time;\\par\r\n\\par\r\n\\cf4 public\\cf2  UserLogInEvent \\cf1 (\\cf2 String userName, Date time\\cf1 )\\cf2\\par\r\n\\cf1\\{\\cf2\\par\r\nthis.userName = userName;\\par\r\nthis.time = time;\\par\r\n\\cf1\\}\\cf2\\par\r\n\\par\r\n\\cf4 private\\cf2  UserLogInEvent\\cf1 ()\\cf2\\par\r\n\\cf1\\{\\cf2\\par\r\nthis.userName = null;\\par\r\nthis.time = null;\\par\r\n\\cf1\\}\\cf2\\par\r\n\\par\r\n\\cf4 public\\cf2  String getUserName\\cf1 ()\\cf2\\par\r\n\\cf1\\{\\cf2\\par\r\n\\cf5 return\\cf2  this.userName;\\par\r\n\\cf1\\}\\cf2\\par\r\n\\cf4 public\\cf2  Date time\\cf1 ()\\cf2\\par\r\n\\cf1\\{\\cf2\\par\r\n\\cf5 return\\cf2  this.time;\\par\r\n\\cf1\\}\\cf2\\par\r\n\\cf1\\}\\cf2\\par\r\n\\cf0\\f0\\fs17\\par\r\nor other example:\\par\r\n\\par\r\n\\cf1\\f1\\fs16\\{\\cf2 UserModifyFile: \\cf1\\{\\cf2 userName:\\cf3 ''Name''\\cf2 ,fileName: \\cf3 ''index.txt''\\cf2  time:\\cf3 ''00.00.00''\\cf1\\}\\}\\cf2\\par\r\n\\cf0\\f0\\fs17\\par\r\n\\par\r\n\\par\r\n\\cf2\\f1\\fs16 UserModifyEvent implement Event \\cf1\\{\\cf2\\par\r\n\\par\r\n\\cf4 private\\cf2   String userName;\\par\r\n\\cf4 private\\cf2  String fileName;\\par\r\n\\cf4 private\\cf2  Date time;\\par\r\n\\par\r\n\\cf4 public\\cf2  UserLogInEvent \\cf1 (\\cf2 String userName, String fileName, Date time\\cf1 )\\cf2\\par\r\n\\cf1\\{\\cf2\\par\r\nthis.userName = userName;\\par\r\nthis.fileName = fileName;\\par\r\nthis.time = time;\\par\r\n\\cf1\\}\\cf2\\par\r\n\\par\r\n\\cf4 private\\cf2  UserLogInEvent\\cf1 ()\\cf2\\par\r\n\\cf1\\{\\cf2\\par\r\nthis.userName = null;\\par\r\nthis.fileName = null;\\par\r\nthis.time = null;\\par\r\n\\cf1\\}\\cf2\\par\r\n\\par\r\n\\cf4 public\\cf2  String getUserName\\cf1 ()\\cf2\\par\r\n\\cf1\\{\\cf2\\par\r\n\\cf5 return\\cf2  this.userName;\\par\r\n\\cf1\\}\\cf2\\par\r\n\\cf4 public\\cf2  Date time\\cf1 ()\\cf2\\par\r\n\\cf1\\{\\cf2\\par\r\n\\cf5 return\\cf2  this.time;\\par\r\n\\cf1\\}\\cf2\\par\r\n\\cf4 public\\cf2  String getFileName \\cf1 ()\\cf2\\par\r\n\\cf1\\{\\cf2\\par\r\n\\cf5 return\\cf2  this.fileName;\\par\r\n\\cf1\\}\\cf2\\par\r\n\\cf0\\f0\\fs17\\}\\par\r\nThe algorithm is very simple:\\par\r\n\\par\r\nstring -> deserialization -> object events created.\\par\r\n\\par\r\nBut .. further problems began. These problems I can not decide ..\\par\r\n\\par\r\nAdded new events.\\par\r\n\\par\r\nInformation that comes with an external system does not contain all necessary data about the event, for example:\\par\r\n\\par\r\n\\cf1\\f1\\fs16\\{\\cf2 UpdateProductInfoEvent: \\cf1\\{\\cf2 userName:\\cf3 ''name''\\cf2 , time: \\cf3 ''00.00.00''\\cf2 , product: \\cf1\\{\\cf2 id:\\cf3 ''123''\\cf2 , name: \\cf3 ''???''\\cf2 , type: \\cf3 ''???''\\cf2 , cost:\\cf3 ''???''\\cf1\\}\\}\\}\\cf2\\par\r\n\\par\r\n\\cf0\\f0\\fs17 As you can see, the line does not contain all the data ... just deserialized not give a desired result ...\\par\r\n\\par\r\nTo do this, I still need to call a method that will receive information about a product by its Id.\\par\r\n\\par\r\nThe algorithm is as follows:\\par\r\n\\par\r\nJSON string -> processing line -> product information from ID -> object creation * Event.\\par\r\n\\par\r\nThe following example:\\par\r\n\\par\r\n\\cf1\\f1\\fs16\\{\\cf2 ModifyProductCatalogEvent:\\cf1\\{\\cf2 userName: \\cf3 ''Name''\\cf2 , time: \\cf3 ''00.00.00''\\cf2 , catalog:\\cf1\\{\\cf2 id:\\cf3 ''321''\\cf2 , catalogType:\\cf3 ''???''\\cf2 , catalogName: \\cf3 ''????''\\cf1\\}\\}\\}\\cf2\\par\r\n\\par\r\n\\cf0\\f0\\fs17 Again I not have all info about catalog...\\par\r\n\\par\r\nSo, I ask for help, how do I properly construct an algorithm to create objects in case of lack of data?\\par\r\n}\r\n', 0),
(73, 21, '2011-06-05 18:20:48', 'C++, ''coupling'' of member pointers in multiple objects copied from the same original object.', '{\\rtf1\\ansi\\ansicpg1252\\deff0\\deflang1033{\\fonttbl{\\f0\\fnil\\fcharset0 Courier New;}{\\f1\\fnil\\fcharset0 Verdana;}}\r\n{\\colortbl ;\\red255\\green165\\blue0;\\red169\\green169\\blue169;\\red0\\green0\\blue255;\\red255\\green0\\blue0;\\red128\\green0\\blue128;\\red0\\green128\\blue0;\\red0\\green0\\blue0;}\r\n\\viewkind4\\uc1\\pard\\cf1\\f0\\fs16 #include <iostream>\\cf2\\par\r\n\\cf1 #include <vector>\\cf2\\par\r\n\\cf1 #include <cstdlib>\\cf2\\par\r\n\\cf1 #include <cassert>\\cf2\\par\r\n\\par\r\n\\cf3 struct\\cf2  s_A \\cf1\\{\\cf2\\par\r\n    \\cf3 bool\\cf2  bin;\\par\r\n    s_A\\cf1 ()\\cf2 : bin\\cf1 (\\cf2 0\\cf1 )\\cf2  \\cf1\\{\\}\\cf2\\par\r\n\\cf1\\}\\cf2 ;\\par\r\n\\par\r\n\\cf3 class\\cf2  c_A \\cf1\\{\\cf2\\par\r\npublic:\\par\r\n    s_A * p_struct;\\par\r\n\\par\r\n    c_A\\cf1 ()\\cf2 : p_struct\\cf1 (\\cf2 NULL\\cf1 )\\cf2  \\cf1\\{\\cf2 p_struct = \\cf4 new\\cf2  s_A \\cf1 [\\cf2 16\\cf1 ]\\cf2 ;\\cf1\\}\\cf2\\par\r\n\\par\r\n    \\cf4 void\\cf2  Reset\\cf1 ()\\cf2\\par\r\n    \\cf1\\{\\cf2\\par\r\n        \\cf5 delete\\cf2  \\cf1 []\\cf2  p_struct;\\par\r\n        p_struct = \\cf4 new\\cf2  s_A \\cf1 [\\cf2 16\\cf1 ]\\cf2 ;\\par\r\n    \\cf1\\}\\cf2\\par\r\n\\cf1\\}\\cf2 ;\\par\r\n\\par\r\n\\cf3 int\\cf2  main \\cf1 ()\\cf2  \\par\r\n\\cf1\\{\\cf2    \\par\r\n    srand\\cf1 (\\cf2 1\\cf1 )\\cf2 ;\\par\r\n    \\cf3 int\\cf2  x = 30;\\par\r\n    std::vector \\cf1 <\\cf2 c_A\\cf1 >\\cf2  objects;\\par\r\n    objects.assign\\cf1 (\\cf2 x, c_A\\cf1 ())\\cf2 ;\\par\r\n    std::vector \\cf1 <\\cf2 c_A\\cf1 >\\cf2  objects_copy;\\par\r\n\\par\r\n    for\\cf1 (\\cf3 int\\cf2  q=0; q \\cf1 <\\cf2  x; q++\\cf1 )\\cf2\\par\r\n    \\cf1\\{\\cf2\\par\r\n        objects_copy.push_back\\cf1 (\\cf2 objects\\cf1 [\\cf2  rand\\cf1 ()\\cf2  % x \\cf1 ])\\cf2 ;\\par\r\n        objects_copy\\cf1 [\\cf2 q\\cf1 ]\\cf2 .Reset\\cf1 ()\\cf2 ;\\par\r\n    \\cf1\\}\\cf2\\par\r\n\\par\r\n    for\\cf1 (\\cf3 int\\cf2  q=0; q \\cf1 <\\cf2  16; q++\\cf1 )\\cf2\\par\r\n        for\\cf1 (\\cf3 int\\cf2  w=0; w \\cf1 <\\cf2  x; w++\\cf1 )\\cf2\\par\r\n        \\cf1\\{\\cf2\\par\r\n            \\cf6 // Assertion should not fail, but it does\\cf2\\par\r\n            assert\\cf1 (\\cf2 !objects_copy\\cf1 [\\cf2 w\\cf1 ]\\cf2 .p_struct\\cf1 [\\cf2 q\\cf1 ]\\cf2 .bin\\cf1 )\\cf2 ;\\par\r\n            objects_copy\\cf1 [\\cf2 w\\cf1 ]\\cf2 .p_struct\\cf1 [\\cf2 q\\cf1 ]\\cf2 .bin = \\cf4 true\\cf2 ;\\par\r\n        \\cf1\\}\\cf2\\par\r\n\\cf1\\}\\par\r\n\\cf2\\par\r\nSomehow the pointers in the different copied objects end up pointing to the same memory, and the assertion eventually fails. This behavior does not happen if run on the un-copied vector.I thought that c_A.Reset() should free up the pointers (via delete[]) to point to a new array, but I''m obviously missing something. \\cf7\\f1\\fs17\\par\r\n}\r\n', 1),
(74, 9, '2011-06-05 20:24:18', 'How i can know how much memory my cached objects are using?', '{\\rtf1\\ansi\\ansicpg1252\\deff0\\deflang1033{\\fonttbl{\\f0\\fnil\\fcharset0 Verdana;}}\r\n\\viewkind4\\uc1\\pard\\f0\\fs17 Hi,\\par\r\n\\par\r\nWe are trying to cache the results of database selects (in hash map), so we wouldn\\rquote t have to execute them multiple times. and whenever we are changing data base, so for getting the changes in app we have added refresh list functionality.\\par\r\n\\par\r\nNow we have a large no of list to fetch, so it taking too much time to load pick list from the data base.\\par\r\n\\par\r\nSo I have some question regarding this issue:\\par\r\n\\par\r\n    How I can find out how much memory the list is using? (I have used the method where we are using garbage collector for collecting the memory and taking the difference but there are many list and so it is taking too much time)\\par\r\n\\par\r\n    How I can optimize the refresh list?\\par\r\n\\par\r\nThanks for the help.\\par\r\n}\r\n', 0),
(75, 8, '2011-06-05 20:34:01', 'Javascript object definition techniques, pros and cons', '{\\rtf1\\ansi\\ansicpg1252\\deff0\\deflang1033{\\fonttbl{\\f0\\fnil\\fcharset0 Verdana;}{\\f1\\fnil\\fcharset0 Courier New;}}\r\n{\\colortbl ;\\red169\\green169\\blue169;\\red255\\green165\\blue0;\\red255\\green0\\blue0;\\red128\\green0\\blue128;\\red0\\green128\\blue0;\\red255\\green192\\blue203;}\r\n\\viewkind4\\uc1\\pard\\f0\\fs17 I''m rather shocked this question doesn''t exist already. Searching around yields various resources, most woefully incomplete, or worse, inaccurate. Not only do I want to know this myself, but I feel that the answer to this question will be a welcome addition to the internet.\\par\r\n\\par\r\nWhat are the basic ways of defining reusable objects in Javascript? I say reusable to exclude singleton techniques, such as declaring a variable with object literal notation directly. I saw somewhere that Crockford defines four such ways in his book(s) but I would rather not have to buy a book for this short bit of information.\\par\r\n\\par\r\nHere are the ways I''m familiar with:\\par\r\n\\par\r\n    Using this, and constructing with new (I think this is called classical?)\\par\r\n\\par\r\n   \\cf1\\f1\\fs16  function Foo\\cf2 ()\\cf1  \\cf2\\{\\cf1\\par\r\n        var \\cf3 private\\cf1  = 3;\\par\r\n        this.add = function\\cf2 (\\cf1 bar\\cf2 )\\cf1  \\cf2\\{\\cf1  \\cf4 return\\cf1  \\cf3 private\\cf1  + bar; \\cf2\\}\\cf1\\par\r\n    \\cf2\\}\\cf1\\par\r\n\\par\r\n    var myFoo = \\cf3 new\\cf1  Foo\\cf2 ()\\cf1 ;\\par\r\n\\cf0\\f0\\fs17\\par\r\n    Using prototypes, which is similar\\par\r\n\\par\r\n   \\cf1\\f1\\fs16  function Foo\\cf2 ()\\cf1  \\cf2\\{\\cf1\\par\r\n        var \\cf3 private\\cf1  = 3;\\par\r\n    \\cf2\\}\\cf1\\par\r\n    Foo.prototype.add = function\\cf2 (\\cf1 bar\\cf2 )\\cf1  \\cf2\\{\\cf1  \\cf5 /* can''t access private, correct? */\\cf6  \\}\\par\r\n\\par\r\n    Returning a literal, not using this or new\\par\r\n\\par\r\n    function Foo() \\{\\par\r\n        var private = 3;\\par\r\n        var add = function(bar) \\{ return private + bar; \\}\\par\r\n        return \\{\\par\r\n            add: add\\par\r\n        \\};\\par\r\n\\cf1     \\cf2\\}\\cf1\\par\r\n\\par\r\n    var myFoo = Foo\\cf2 ()\\cf1 ;\\par\r\n\\cf0\\f0\\fs17\\par\r\nI can think of relatively minor variations on these that probably don''t matter in any significant way. What styles am I missing? More importantly, what are the pros and cons of each? Is there a recommended one to stick to, or is it a matter of preference and a holy war?\\par\r\n}\r\n', 0),
(76, 7, '2011-06-05 20:52:06', 'What''s a good sample problem to test for skills in PHP?', '{\\rtf1\\ansi\\ansicpg1252\\deff0\\deflang1033{\\fonttbl{\\f0\\fnil\\fcharset0 Verdana;}}\r\n\\viewkind4\\uc1\\pard\\f0\\fs17 I want to give a new developer a problem to test his BASIC PHP skills.\\par\r\n\\par\r\nAny help?\\par\r\n}\r\n', 1),
(77, 15, '2011-06-05 20:56:31', 'Is this plausible in C/C++ socket communication?', '{\\rtf1\\ansi\\ansicpg1252\\deff0\\deflang1033{\\fonttbl{\\f0\\fnil\\fcharset0 Verdana;}{\\f1\\fnil\\fcharset0 Courier New;}}\r\n{\\colortbl ;\\red0\\green0\\blue255;\\red169\\green169\\blue169;\\red255\\green165\\blue0;\\red255\\green0\\blue0;}\r\n\\viewkind4\\uc1\\pard\\f0\\fs17 I currently have a basic client/server setup. The server needs to take requests from client(s) and need to respond to different request message types. An example of client request could be get list of files available, how many other clients are connected to the server, etc.\\par\r\n\\par\r\nI would obviously have to figure out a way to determine the type of message from the message received from the sender. I was wondering, if I have a struct defined with necessary data, whehter if I can cast the struct to void*, send it as through send(sockfd, message, length, flags) syscall, and than on the receiver side, cast it back to the struct. This of course assumes that I am running the client and server in a same environment.\\par\r\n\\par\r\nFor example, if I have the following struct:\\par\r\n\\par\r\n\\cf1\\f1\\fs16 struct\\cf2  message \\cf3\\{\\cf2\\par\r\n   \\cf1 enum\\cf2  messageType \\cf3\\{\\cf2  GET_FILES, GET_CLINET_NUMBER\\cf3\\}\\cf2  messageType,\\par\r\n\\cf3\\}\\cf2  \\cf0\\f0\\fs17\\par\r\n\\par\r\nand use this struct to send the message in following way\\par\r\n\\par\r\n\\cf1\\f1\\fs16 struct\\cf2  message msg;\\par\r\nmsg.messageType = GET_FILES;\\par\r\nsend\\cf3 (\\cf2 server_sockfd, \\cf3 (\\cf2 void*\\cf3 )\\cf2 &msg, \\cf4 sizeof\\cf3 (\\cf1 struct\\cf3 )\\cf2 , 0\\cf3 )\\cf0\\f0\\fs17\\par\r\n\\par\r\nand on the receiver,\\par\r\n\\par\r\n\\cf2\\f1\\fs16 recv\\cf3 (\\cf2 ,msg_buffer\\cf3 )\\cf2 ;\\par\r\n\\cf1 struct\\cf2  message received = \\cf3 (\\cf1 struct\\cf2  message*\\cf3 )\\cf2 msg_buffer;\\cf0\\f0\\fs17\\par\r\n\\par\r\nIgnoring the minor syntactical issues, can anyone advise if this scheme is possible? If not, is there any other way to pass a message without sending raw char*?\\par\r\n}\r\n', 1);

-- --------------------------------------------------------

--
-- Table structure for table `question_resource`
--

CREATE TABLE IF NOT EXISTS `question_resource` (
  `id_question` int(10) unsigned NOT NULL,
  `id_resource` int(10) unsigned NOT NULL,
  PRIMARY KEY (`id_question`,`id_resource`),
  KEY `fk_question_resource_question` (`id_question`),
  KEY `fk_question_resource_resource` (`id_resource`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `question_resource`
--

INSERT INTO `question_resource` (`id_question`, `id_resource`) VALUES
(60, 1),
(62, 18),
(63, 17),
(66, 4),
(66, 11),
(69, 1),
(69, 8),
(71, 8),
(72, 11),
(72, 14),
(73, 1),
(75, 14),
(76, 18),
(77, 1),
(77, 8),
(77, 9);

-- --------------------------------------------------------

--
-- Table structure for table `quiz_item`
--

CREATE TABLE IF NOT EXISTS `quiz_item` (
  `id_quiz_item` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `question_quiz_item` varchar(200) NOT NULL,
  `a_quiz_item` varchar(200) NOT NULL,
  `b_quiz_item` varchar(200) NOT NULL,
  `c_quiz_item` varchar(200) NOT NULL,
  `d_quiz_item` varchar(200) NOT NULL,
  `correct_quiz_item` tinyint(4) NOT NULL,
  PRIMARY KEY (`id_quiz_item`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=42 ;

--
-- Dumping data for table `quiz_item`
--

INSERT INTO `quiz_item` (`id_quiz_item`, `question_quiz_item`, `a_quiz_item`, `b_quiz_item`, `c_quiz_item`, `d_quiz_item`, `correct_quiz_item`) VALUES
(1, 'Which of the following statements is correct ?', 'new() and malloc() are operators', 'free() frees the allocated memory by an object and calls its destructor', 'Unlike malloc(), new() can allocate memory at a given address', 'delete() cannot be overwritten', 2),
(2, 'In C++, a class:', 'can be declared abstract using the keyword ''abstract''', 'can have a private constructor', 'has to explicitly declare a constructor', 'can have numerous destructors', 1),
(3, 'In C++, what is the difference between a structure and a class?', 'There is no difference.', 'A structure cannot define constructors.', 'In a structure, methods cannot be defined.', 'The default domain regarding vizibility of fields.', 3),
(4, 'Which of the following STL defined containers is not associative?', 'set', 'map', 'bitset', 'priority_queue', 3),
(5, 'dynamic_cast can be used to convert:', 'int to short int', 'short int to int', 'a class to one of its base classes', 'a class to one of its derived classes', 2),
(6, 'How many bytes occupies a class that hasn''t declared neither a method nor a variable?', '0', '1', '4', '8', 1),
(7, 'Which of the following methods is not defined in STL class queue ?', 'front', 'push', 'pop', 'top', 0),
(8, 'What is the complexity of MergeSort algorithm?', 'O(1)', 'O(N)', 'O(N log N)', 'O(N^2)', 2),
(9, 'Which of the following data structures allow inserting, removing and searching an element in O(logN) ?', 'Red-black Tree', 'Heaps', 'Binary Search Tree', 'Doubly Linked Lists', 0),
(10, 'Which of the following algorithms is not used for Pattern Matching ?', 'Rabin-Karp', 'Boyer-Moore', 'Roy-Floyd', 'Knuth-Morris-Pratt', 2),
(11, 'Which of the following problems is not NP ?', 'Determine a hamiltonian path of minimum cost in a graph', 'Determine a hamiltonian path of minimum cost in a complete graph', 'Determine a eulerian cycle in a graph', '3SAT', 2),
(12, 'Searching an element in a sorted array has a minimum complexity of:', 'O(1)', 'O(log n)', 'O(n)', 'O(n^2)', 1),
(13, 'In NIM game, the second player wins the game if :', 'the number of the rocks from the piles is even.', 'the number of the rocks from the piles is odd.', 'the XOR sum of the rocks from the piles is zero.', 'the XOR sum of the rocks from the piles is non-zero.', 2),
(14, 'On a 32-bit architecture, sizeof(long long *) is equal to:', '2', '4', '8', '16', 1),
(15, 'Which of the following statements is incorrect ?', 'Macros can have expressions.', 'Macros are evaluated at run-time.', 'Macros can have parameters.', 'Macros cannot be changed at run-time.', 1),
(16, 'Which of the following operators is "right associative" in C?', '=', ',', '^', '->', 0),
(17, 'Which of the following expressions is correct ?', '(long long)1000000*1000000 == 1000000000000LL', '(long long)(1000000*1000000) == 1000000000000LL', '(long long)1000000*1000000 == 1000000000000', '1000000 * 1000000  == 1000000000000LL', 0),
(18, 'If initially x equals zero, the following expression (x^=x) || x++ || ++x || x++ returns :', '0', '1', '2', '3', 2),
(19, 'Which of the following functions is used to copy a block of memory from a location to another ?', 'strset', 'strcpy', 'memset', 'memcpy', 3),
(20, 'In which header is the printf() function located ?', 'stdio.h', 'stdin.h', 'stdout.h', 'stdlib.h', 0),
(21, 'A class can be converted to a thread by implementing : ', 'Thread', 'SystemThread', 'Runnable', 'IThread', 2),
(22, 'Which of the following operations causes a compilling error ?', 'int[ ] scores = {3, 5, 7};', 'int [ ][ ] scores = {2,7,6}, {9,3,45};', 'String cats[ ] = {"Fluffy", "Spot", "Zeus"};', 'boolean results[ ] = new boolean [] {true, false, true};', 1),
(23, 'What methods does HttpSessionListener contains ?', 'sessionCreated, sessionReplaced', 'sessionDestroyed, sessionReplaced', 'sessionDestroyed, sessionCreated', 'sessionCreated, sessionReplaced, sessionDestroyed', 2),
(24, 'Which two constructors are valid ?', 'Thread(Runnable r, String name); Thread(int priority)', 'Thread(Runnable r, String name); Thread()', 'Thread(); Thread(Runnable r, ThreadGroup g)', 'Thread(Runnable r, int priority); Thread()', 1),
(25, 'Which of the following classes does not overwrite equals() and hashCode() from Object?', 'java.lang.String', 'java.lang.Double', 'java.lang.StringBuffer', 'java.lang.Character', 2),
(26, 'What interface does java.util.HashTable implement ?', 'Java.util.Map', 'Java.util.List', 'Java.util.Collection', 'Java.util.HashTable', 0),
(27, 'What is the most restrictive access modifier that allows classes included in a package to have access to all the members of the same package ?', 'default access', 'protected', 'syncronized', 'public', 0),
(29, 'Which of the following scope variables is not supported by PHP ?', 'Local variables', 'Function parameters', 'Hidden variables', 'Global variables', 2),
(30, 'Which of the following is a value assignment  ?', ' $value1= $value', ' $value1 == $value', '$value1 != $value', 'None of the above', 0),
(31, 'Which of the following functions requires activation of allow-url-fopen?', 'include()', 'require()', 'both of them', 'none of them', 2),
(32, '''%'' operator with left-association is used to ?', 'percentage', 'OR bit operation', 'divide', 'mod', 3),
(33, 'Which of the following identifiers is valid?', 'my-function', 'size', '–some word', 'This&that', 3),
(34, 'Which of the following casts is introduced in PHP 6?', '(array)', '(int64)', '(real) or (double) or (float)', '(object)', 1),
(35, 'In PHP, letters from a string are separated by:', '''', '''''', '<<<', 'all of the above', 3),
(36, 'API term stands for :', 'Application Programming Interface', 'Application Parse Interface', 'Application Programming Implementation', 'Application Program Index', 0),
(37, 'An object state is stored in :', 'fields', 'methods', 'classes', 'atrributes', 0),
(38, 'Hiding intern data and accessing them only through public methods is known as :', 'abstractization', 'encapsulation', 'changing access rights', 'synchronization', 1),
(39, 'Can a class enherit more than one class ?', 'Yes', 'No', 'Depends on the language', 'Depends on the operating system', 2),
(40, 'The process of transforming objects in byte streams is known as :', 'encapsulation', 'serialization', 'byte converter', 'bit converter', 1),
(41, 'A method collection without implementation is known as :', 'Object', 'Class', 'Superclass', 'Interface', 3);

-- --------------------------------------------------------

--
-- Table structure for table `resource`
--

CREATE TABLE IF NOT EXISTS `resource` (
  `id_resource` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `owner_user` int(10) unsigned NOT NULL,
  `id_domain` int(10) unsigned NOT NULL,
  `timestamp_resource` datetime NOT NULL,
  `title_resource` varchar(200) NOT NULL,
  `description_resource` varchar(1000) NOT NULL,
  `links_resource` varchar(1000) DEFAULT NULL,
  `category_resource` int(11) NOT NULL,
  `rank_resource` double unsigned zerofill NOT NULL,
  PRIMARY KEY (`id_resource`),
  KEY `fk_resource_owner` (`owner_user`),
  KEY `fk_resource_domain` (`id_domain`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=28 ;

--
-- Dumping data for table `resource`
--

INSERT INTO `resource` (`id_resource`, `owner_user`, `id_domain`, `timestamp_resource`, `title_resource`, `description_resource`, `links_resource`, `category_resource`, `rank_resource`) VALUES
(1, 2, 3, '2011-06-01 19:40:36', 'C++ dot com', 'A very useful and complete site of all that is related to the C++ language. Whenever your Google Search returns this entry (probably the first one, most of the time), it will prove itself as an on-the-spot reference for your problem.', '[0] www.cplusplus.com', 0, 00000000000000000018.6),
(2, 2, 3, '2011-06-01 19:43:42', 'Operator Overloading', 'C++ gives the possibility to overload the main function of operators for a specific class. It is a very powerful tool in handling objects and writing cleaner code. Find more in the links.', '[0] http://www.cs.caltech.edu/courses/cs11/material/cpp/donnie/cpp-ops.html\n[1] http://msdn.microsoft.com/en-us/library/5tk49fh2%28v=vs.80%29.aspx', 1, 00000000000000000009.2),
(3, 2, 3, '2011-06-01 19:55:07', 'Multiple Inheritance', 'This option allows you to have more than one base class for your derived class. This gives you a wider range of methods inherited, but it also involves some internal handling of conflicts. It is only specific to the C++ language.', '[0] http://en.wikipedia.org/wiki/Multiple_inheritance\n[1] http://publib.boulder.ibm.com/infocenter/comphelp/v8v101/index.jsp?topic=%2Fcom.ibm.xlcpp8a.doc%2Flanguage%2Fref%2Fcplr134.htm', 1, 00000000000000000005.4),
(4, 3, 1, '2011-06-01 19:59:09', 'Introduction to Algorithms', 'Probably the best and most through material on the subject. It is a book written by Cormen, Leiserson and Rivest. You can find it in most of the libraries and also on online book stores. It should be in every programmer''s fundamental knowledge on this topic, and you can find most of the classic problems and algorithms here.', '', 0, 00000000000000000010.9),
(5, 3, 1, '2011-06-01 20:05:30', 'Heaps', 'A very know and widely-used tree-like data-structure, known for its logarithmic handling complexity. Heap implementations vary from language to language, but the structures themselves prove efficient in sorting algorithms and dynamic programming.', '[0] http://en.wikipedia.org/wiki/Heap_%28data_structure%29', 1, 00000000000000000007.8),
(6, 3, 1, '2011-06-01 20:21:01', 'Binary Search Tree', 'A special type of binary tree, that keeps its elements sorted according to a certain criteria. An in-order traversing of the tree outputs the elements in sorted order. An animated example of how the structure works can be found at [1].', '[0] http://en.wikipedia.org/wiki/Binary_search_tree\n[1] http://www.cs.jhu.edu/~goodrich/dsa/trees/btree.html', 0, 00000000000000000013.2),
(7, 4, 3, '2011-06-01 20:30:05', 'C++ for Java programmers', 'A tutorial that makes it easier for Java programmers to migrate to and better understand the C++ language. Check links.', '[0] http://swarm.cs.pub.ro/~adrian.sc/PA/TutorialC++.pdf', 0, 00000000000000000015.6),
(8, 3, 2, '2011-06-01 20:34:23', 'GNU C library', 'The main reference manual for the GNU standard C library. Useful for both complete begginers and expert users. Downloadable for free from the GNU site.', '[0] www.gnu.org/s/libc/manual/pdf/libc.pdf', 0, 00000000000000000010.4),
(9, 3, 2, '2011-06-01 20:37:27', 'Structures', 'Structures are the main method of data encapsulation in C. Using structures, an user is able to declare and access his data similar to classes in OOP. A basic tutorial is available in the Links section.', '[0] http://publications.gbdirect.co.uk/c_book/chapter6/structures.html', 0, 00000000000000000014.3),
(10, 3, 2, '2011-06-01 20:50:37', 'Arrays', 'Arrays are a method to declare contiguous memory in a C program. The array type specifies the datatype of the records stored in that memory. Using arrays may simplify the process of declaring and accessing data.', '[0] http://www.exforsys.com/tutorials/c-language/c-arrays.html', 1, 00000000000000000006.5),
(11, 3, 4, '2011-06-01 20:52:43', 'Javadoc', 'An official documentation for the Java language can be downloaded and integrated in an IDE (Eclipse, JCreator, etc.) from the official site, listed below.', '[0] http://download.oracle.com/javase/6/docs/', 0, 00000000000000000005.3),
(12, 3, 4, '2011-06-01 20:55:54', 'JVM', 'The Java Virtual Machine (JVM) is a platform-independent process that runs as an interpreter and compiler for Java code. This component makes it possible to write code that can easily be ported on all platforms that support its requierements.', '[0] en.wikipedia.org/wiki/Java_Virtual_Machine\n[1] java.sun.com/docs/books/jvms/', 0, 00000000000000000014.3),
(13, 3, 4, '2011-06-01 20:56:40', 'StringTokenizer', 'The string tokenizer class allows an application to break a string into tokens. The tokenization method is much simpler than the one used by the StreamTokenizer class. The StringTokenizer methods do not distinguish among identifiers, numbers, and quoted strings, nor do they recognize and skip comments.', '[0] http://download.oracle.com/javase/1.4.2/docs/api/java/util/StringTokenizer.html', 1, 00000000000000000014.3),
(14, 3, 5, '2011-06-01 20:58:33', 'Java OOP Concepts', 'If you''ve never used an object-oriented programming language before, you''ll need to learn a few basic concepts before you can begin writing any code. This lesson will introduce you to objects, classes, inheritance, interfaces, and packages. Each discussion focuses on how these concepts relate to the real world, while simultaneously providing an introduction to the syntax of the Java programming language.', '[0] http://download.oracle.com/javase/tutorial/java/concepts/', 0, 00000000000000000009.2),
(15, 3, 5, '2011-06-01 21:00:01', 'Inheritance', 'In object oriented programming, objects will be characterised by classes. It is possible to learn a lot about an object based on the class it belongs to. Even if you are not familiar with the name Maybach, If I told you it is a car, you would immediately know that it has four wheels, an engine, and doors. Objected oriented programming takes this concept to a whole new level.', '[0] http://www.exforsys.com/tutorials/oops/the-inheritance-concept-in-oops.html\n[1] http://en.wikipedia.org/wiki/Inheritance_%28object-oriented_programming%29\n[2] http://en.kioskea.net/contents/poo/heritage.php3', 0, 00000000000000000011.8),
(16, 3, 5, '2011-06-01 21:01:01', 'Destructors', 'Whenever an object is destroyed and removed from memory, the object''s destructor is called. In object-oriented programming, a destructor gives an object a last chance to clean up any memory it allocated or perform any other tasks that must be completed before the object is destroyed.', '[0] http://www.informit.com/articles/article.aspx?p=25856&seqNum=9', 1, 0000000000000000000000),
(17, 3, 6, '2011-06-01 21:03:54', 'Interface', 'Interface is a special class used like a template for a group of classes with similar functions, which must define a certain structure of methods. A video tutorial can be found at [1].', '[0] http://www.coursesweb.net/php-mysql/php-oop-interfaces\n[1] http://www.youtube.com/watch?v=MGg59WZb4U8', 1, 00000000000000000005.3),
(18, 3, 6, '2011-06-01 21:05:52', 'PHP dot net', 'An extended information site for all matters concerning PHP.', '[0] http://www.php.net', 0, 000015.799999999999999),
(19, 5, 3, '2011-06-01 21:34:28', 'Deep Copy vs. Shallow Copy', 'The terms "deep copy" and "shallow copy" refer to the way objects are copied, for example, during the invocation of a copy constructor or assignment operator. In a deep copy (also called "memberwise copy"), the copy operation respects object semantics. For example, copying an object that has a member of type std::string ensures that the corresponding std::string in the target object is copy-constructed by the copy constructor of class std::string.', '[0] http://www.devx.com/tips/Tip/13625', 1, 00000000000000000016.9),
(20, 6, 3, '2011-06-01 21:35:47', 'VoidType', 'A function with void result type ends either by reaching the end of the function or by executing a return statement with no returned value. The void type may also appear as the sole argument of a function prototype to indicate that the function takes no arguments. Note that despite the name, in all of these situations, the void type serves as a unit type, not as a zero or bottom type, even though unlike a real unit type which is a singleton, the void type is said to comprise an empty set of values, and the language does not provide any way to declare an object or represent a value with type void.', '[0] http://en.wikipedia.org/wiki/Void_type', 0, 00000000000000000005.2),
(21, 7, 3, '2011-06-01 21:37:18', 'String Class', 'String objects are a special type of container, specifically designed to operate with sequences of characters.', '[0] http://www.cplusplus.com/reference/string/string/\n[1] http://anaturb.net/C/string_exapm.htm', 0, 00000000000000000007.9),
(22, 8, 3, '2011-06-01 21:38:29', 'Local Class', 'A local class is declared within a function definition. Declarations in a local class can only use type names, enumerations, static variables from the enclosing scope, as well as external variables and functions.', '[0] http://publib.boulder.ibm.com/infocenter/comphelp/v8v101/index.jsp?topic=%2Fcom.ibm.xlcpp8a.doc%2Flanguage%2Fref%2Fcplr062.htm', 1, 00000000000000000014.3),
(23, 9, 3, '2011-06-01 21:39:31', 'Nested Class', 'A nested class is declared within the scope of another class. The name of a nested class is local to its enclosing class. Unless you use explicit pointers, references, or object names, declarations in a nested class can only use visible constructs, including type names, static members, and enumerators from the enclosing class and global variables.', '[0] http://publib.boulder.ibm.com/infocenter/comphelp/v8v101/index.jsp?topic=%2Fcom.ibm.xlcpp8a.doc%2Flanguage%2Fref%2Fcplr061.htm', 1, 00000000000000000003.9),
(24, 10, 3, '2011-06-01 21:40:59', 'Static Keyword', 'When modifying a variable, the static keyword specifies that the variable has static duration (it is allocated when the program begins and deallocated when the program ends) and initializes it to 0 unless another value is specified. When modifying a variable or function at file scope, the static keyword specifies that the variable or function has internal linkage (its name is not visible from outside the file in which it is declared).', '[0] http://msdn.microsoft.com/en-us/library/s1sb61xd%28v=vs.80%29.aspx', 0, 00000000000000000009.2),
(25, 11, 3, '2011-06-01 21:44:30', 'Storage Specifiers', 'This C++ Tutorial concentrates on some of the storage class specifiers in C++. The storage class specifiers are used to change the way of creating the memory storage for the variables.', '[0] http://www.codersource.net/c/c-tutorials/c-tutorial-storage-specifiers.aspx', 0, 00000000000000000018.3),
(27, 12, 3, '2011-06-01 22:11:08', 'Copy Contructor', 'If a copy constructor is not defined in a class, the compiler itself defines one. This will ensure a shallow copy. If the class does not have pointer variables with dynamically allocated memory, then one need not worry about defining a copy constructor. It can be left to the compiler''s discretion.', '[0] http://www.codersource.net/c/c-miscellaneous/c-copy-constructors.aspx\n[1] http://en.wikipedia.org/wiki/Copy_constructor', 1, 00000000000000000019.6);

-- --------------------------------------------------------

--
-- Table structure for table `resource_vote`
--

CREATE TABLE IF NOT EXISTS `resource_vote` (
  `id_resource` int(10) unsigned NOT NULL,
  `id_user` int(10) unsigned NOT NULL,
  `value_resource_vote` int(11) DEFAULT NULL,
  PRIMARY KEY (`id_resource`,`id_user`),
  KEY `fk_resource_vote_resource` (`id_resource`),
  KEY `fk_resource_vote_voter` (`id_user`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `resource_vote`
--

INSERT INTO `resource_vote` (`id_resource`, `id_user`, `value_resource_vote`) VALUES
(1, 2, 4),
(1, 3, 4),
(1, 4, 5),
(1, 5, 5),
(1, 6, 2),
(1, 7, 5),
(2, 2, 5),
(2, 3, 1),
(2, 4, 3),
(2, 5, 4),
(2, 6, 5),
(3, 2, 4),
(3, 3, 3),
(3, 4, 1),
(3, 5, 2),
(3, 6, 3),
(3, 7, 5),
(4, 2, 5),
(4, 3, 5),
(4, 4, 5),
(4, 6, 2),
(5, 2, 2),
(5, 3, 3),
(5, 4, 3),
(5, 5, 3),
(5, 6, 5),
(6, 2, 4),
(6, 3, 4),
(6, 5, 5),
(6, 6, 5),
(7, 2, 5),
(7, 3, 1),
(7, 4, 5),
(7, 5, 4),
(7, 6, 5),
(7, 7, 5),
(8, 2, 5),
(8, 3, 1),
(8, 4, 5),
(8, 5, 5),
(8, 6, 3),
(9, 2, 2),
(9, 3, 5),
(9, 4, 4),
(9, 5, 5),
(9, 6, 5),
(10, 2, 5),
(10, 3, 4),
(10, 4, 4),
(10, 5, 1),
(11, 2, 4),
(11, 3, 1),
(11, 5, 3),
(11, 6, 5),
(12, 2, 5),
(12, 3, 5),
(12, 4, 4),
(12, 5, 5),
(13, 2, 5),
(13, 3, 5),
(13, 4, 3),
(13, 5, 5),
(13, 6, 3),
(14, 2, 3),
(14, 3, 3),
(14, 4, 4),
(14, 5, 5),
(15, 2, 5),
(15, 3, 5),
(15, 5, 5),
(16, 2, 3),
(16, 3, 1),
(16, 5, 2),
(17, 2, 4),
(17, 3, 3),
(17, 5, 3),
(18, 2, 5),
(18, 3, 5),
(18, 4, 5),
(18, 5, 5),
(19, 2, 5),
(19, 3, 4),
(19, 4, 3),
(19, 5, 3),
(19, 6, 5),
(19, 7, 5),
(20, 2, 4),
(20, 3, 5),
(20, 4, 4),
(20, 5, 1),
(20, 6, 1),
(20, 7, 3),
(21, 2, 3),
(21, 3, 3),
(21, 4, 5),
(21, 5, 4),
(21, 6, 3),
(21, 7, 1),
(22, 2, 5),
(22, 3, 5),
(22, 4, 5),
(22, 5, 4),
(23, 2, 5),
(23, 3, 4),
(23, 4, 4),
(23, 5, 1),
(23, 7, 1),
(24, 2, 3),
(24, 3, 4),
(24, 4, 3),
(24, 5, 2),
(24, 6, 5),
(24, 7, 3),
(25, 2, 5),
(25, 3, 4),
(25, 4, 3),
(25, 5, 5),
(25, 6, 4),
(25, 7, 5),
(27, 2, 4),
(27, 3, 4),
(27, 4, 4),
(27, 5, 5),
(27, 6, 5),
(27, 7, 5);

-- --------------------------------------------------------

--
-- Table structure for table `user`
--

CREATE TABLE IF NOT EXISTS `user` (
  `id_user` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `username_user` varchar(32) NOT NULL,
  `password_user` varchar(128) NOT NULL,
  `email_user` varchar(50) NOT NULL,
  `status_user` tinyint(1) NOT NULL DEFAULT '0',
  `rank_user` double unsigned NOT NULL DEFAULT '0',
  PRIMARY KEY (`id_user`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=22 ;

--
-- Dumping data for table `user`
--

INSERT INTO `user` (`id_user`, `username_user`, `password_user`, `email_user`, `status_user`, `rank_user`) VALUES
(1, 'test', '098f6bcd4621d373cade4e832627b4f6', 'test@tonicpride.ro', 0, 36.2258227952),
(2, 'smith', '11285b4acc3330051b3c8d011d0d662d', 'smith@smith.com', 0, 49.8384969216),
(3, 'johnson', '59cdc1e9a895141b653c8b56bf5fc506', 'johnson@johnson.com', 0, 82.8906252965),
(4, 'jones', '8645f1f136740b1fc85a0568d945eac0', 'jones@jones.com', 0, 49.35932411280001),
(5, 'davis', 'f24405e26a9b2651b06928fedbe9cbe4', 'davis@davis.com', 0, 30.062908317799995),
(6, 'miller', '596049900552a6c647386c7c6cd9916f', 'miller@miller.com', 0, 40.854932581400014),
(7, 'brown', 'e942f5145baab4bba8ba83b9ab814401', 'brown@brown.com', 0, 36.7754627555),
(8, 'wilson', 'd2ad21a6191a386fb770cd1628bfdb25', 'wilson@wilson.com', 0, 36.81296497590002),
(9, 'moore', '96b5d25eb7d29f046fa762427689db7e', 'moore@moore.com', 0, 44.52301075550001),
(10, 'taylor', 'ede087847c63f8684e04900b0f1c47ed', 'taylor@taylor.com', 0, 35.87450098100001),
(11, 'anderson', '678cc034f76550e28741154c6662211c', 'anderson@anderson.com', 0, 31.465133725399998),
(12, 'william', '76fecaab54ba086590f6d4e92226845f', 'william@william.com', 0, 35.162075550500006),
(13, 'white', '63fffdb634c335b8140dd9cc80dba676', 'white@white.com', 0, 1.0115100977),
(14, 'thomas', 'e1e31a7beeb0e27a57f8257da9df103b', 'thomas@thomas.com', 0, 21.538646144299996),
(15, 'jackson', '01c51a1e16cb12965709068cc2276521', 'jackson@jackson.com', 0, 32.3158830675),
(16, 'harris', '4d1bf43d9e45b9c2eec3ceb71ec5f1e1', 'harris@harris.com', 0, 40.1761833574),
(17, 'martin', '17f271c1ae2c705da509b71e671ce90b', 'martin@martin.com', 0, 30.6491055283),
(18, 'thompson', 'c1385284624ce49d1784cf07ee9a895d', 'thompson@thompson.com', 0, 20.238538923900002),
(19, 'garcia', '5e6d619b10261cb66ffafce8b43169c3', 'garcia@garcia.com', 0, 40.999464848100004),
(20, 'martin', '17f271c1ae2c705da509b71e671ce90b', 'martin@martin.com', 0, 21.1),
(21, 'robinson', '16e75982092027ff6ca4672e9df6d9c4', 'robinson@robinson.com', 0, 31.622195428599998);

-- --------------------------------------------------------

--
-- Table structure for table `user_vote`
--

CREATE TABLE IF NOT EXISTS `user_vote` (
  `id_voter_user` int(10) unsigned NOT NULL,
  `id_votee_user` int(10) unsigned NOT NULL,
  `id_question` int(10) unsigned NOT NULL,
  `value_user_vote` int(11) DEFAULT NULL,
  PRIMARY KEY (`id_voter_user`,`id_votee_user`,`id_question`),
  KEY `fk_user_vote_voter` (`id_voter_user`),
  KEY `fk_user_vote_votee` (`id_votee_user`),
  KEY `fk_user_vote_question` (`id_question`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `user_vote`
--

INSERT INTO `user_vote` (`id_voter_user`, `id_votee_user`, `id_question`, `value_user_vote`) VALUES
(3, 5, 73, 4),
(3, 6, 74, 3),
(6, 3, 74, 4),
(15, 11, 77, 5),
(15, 12, 77, 5);

-- --------------------------------------------------------

--
-- Table structure for table `validation`
--

CREATE TABLE IF NOT EXISTS `validation` (
  `id_user` int(10) unsigned NOT NULL,
  `id_domain` int(10) unsigned NOT NULL,
  PRIMARY KEY (`id_domain`,`id_user`),
  KEY `fk_validation_user` (`id_user`),
  KEY `fk_validation_domain` (`id_domain`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `validation`
--

INSERT INTO `validation` (`id_user`, `id_domain`) VALUES
(1, 1),
(1, 2),
(1, 3),
(1, 4),
(1, 5),
(2, 3),
(3, 1),
(3, 2),
(3, 3),
(3, 4),
(3, 5),
(3, 6),
(4, 3),
(5, 3),
(6, 3),
(7, 3),
(8, 3),
(9, 3),
(10, 3),
(11, 3),
(12, 3),
(13, 3),
(14, 3),
(15, 3),
(16, 3),
(17, 3),
(18, 3),
(19, 3),
(20, 3),
(21, 3);

--
-- Constraints for dumped tables
--

--
-- Constraints for table `domain_question`
--
ALTER TABLE `domain_question`
  ADD CONSTRAINT `fk_domain_question_domain` FOREIGN KEY (`id_domain`) REFERENCES `domain` (`id_domain`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_domain_question_question` FOREIGN KEY (`id_question`) REFERENCES `question` (`id_question`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `domain_quiz_item`
--
ALTER TABLE `domain_quiz_item`
  ADD CONSTRAINT `fk_domain_quiz_item_domain` FOREIGN KEY (`id_domain`) REFERENCES `domain` (`id_domain`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_domain_quiz_item_quiz_item` FOREIGN KEY (`id_quiz_item`) REFERENCES `quiz_item` (`id_quiz_item`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `friendship`
--
ALTER TABLE `friendship`
  ADD CONSTRAINT `fk_friendship_user1` FOREIGN KEY (`id_former_user`) REFERENCES `user` (`id_user`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_friendship_user2` FOREIGN KEY (`id_latter_user`) REFERENCES `user` (`id_user`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `log`
--
ALTER TABLE `log`
  ADD CONSTRAINT `fk_log_owner` FOREIGN KEY (`owner_user`) REFERENCES `user` (`id_user`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_log_question` FOREIGN KEY (`question_question`) REFERENCES `question` (`id_question`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `question`
--
ALTER TABLE `question`
  ADD CONSTRAINT `fk_question_owner` FOREIGN KEY (`owner_user`) REFERENCES `user` (`id_user`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `question_resource`
--
ALTER TABLE `question_resource`
  ADD CONSTRAINT `fk_question_resource_question` FOREIGN KEY (`id_question`) REFERENCES `question` (`id_question`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_question_resource_resource` FOREIGN KEY (`id_resource`) REFERENCES `resource` (`id_resource`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `resource`
--
ALTER TABLE `resource`
  ADD CONSTRAINT `fk_resource_domain` FOREIGN KEY (`id_domain`) REFERENCES `domain` (`id_domain`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_resource_owner` FOREIGN KEY (`owner_user`) REFERENCES `user` (`id_user`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `resource_vote`
--
ALTER TABLE `resource_vote`
  ADD CONSTRAINT `fk_resource_vote_resource` FOREIGN KEY (`id_resource`) REFERENCES `resource` (`id_resource`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_resource_vote_voter` FOREIGN KEY (`id_user`) REFERENCES `user` (`id_user`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `user_vote`
--
ALTER TABLE `user_vote`
  ADD CONSTRAINT `fk_user_vote_question` FOREIGN KEY (`id_question`) REFERENCES `question` (`id_question`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_user_vote_votee` FOREIGN KEY (`id_votee_user`) REFERENCES `user` (`id_user`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_user_vote_voter` FOREIGN KEY (`id_voter_user`) REFERENCES `user` (`id_user`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `validation`
--
ALTER TABLE `validation`
  ADD CONSTRAINT `fk_validation_domain` FOREIGN KEY (`id_domain`) REFERENCES `domain` (`id_domain`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_validation_user` FOREIGN KEY (`id_user`) REFERENCES `user` (`id_user`) ON DELETE NO ACTION ON UPDATE NO ACTION;
