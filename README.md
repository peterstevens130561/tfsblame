tfsblame
========

Attempt to create a tfs blame, in line with other blames

The problem with the tfs blame version, better known as tfpt annotate is that it is not compatible with other blames, like svn, git, cvs etc, in that it does not provide the committer and the date of the commit: the developers decided that if you're interested in that you should use the gui version. And maybe they are right.

However, this decision makes tfs difficult to use in a sonar environment if you want to use differential views: the scm-activity plugin uses the apache maven-scm project, which relies on an earlier version of tfpt annotate, which did provide the capabilities.

To make a long story short: tfsblame provides commit, name of committer, date+time of commit, line

name of committer is the CommitterDisplayName.Replace(" ","_")
date+time of commit is of the format 2014/11/23T16:15:20

Should you be interested in using this tfsblame in your sonar activity, then you need to do the following
1. get scm-activity from my repo
2. get maven-scm from my repo
3. build both
4. install scm-activity on your sonar
5. install tfpt on your build server
6. get tfsblame, build and install


try tfsblame on a file in the tfs repo.
