# Git Notes

Edit your bash profile to display current branch:
```
nano ~/.bash_profile
```

Paste the following:
```
parse_git_branch() {
     git branch 2> /dev/null | sed -e '/^[^*]/d' -e 's/* \(.*\)/ (\1)/'
}
export PS1="\u@\h \[\033[32m\]\w\[\033[33m\]\$(parse_git_branch)\[\033[00m\] $ "
```

Clone Existing Project
```
git clone https://github.com/facebookincubator/create-react-app.git
```

Create New Project
```
mkdir ~/myproject
cd ~/myproject
```

Create new file, add, commit, push
```
echo "# testing" >> README.md
git add README.md
git commit -m "Added README file" README.md
```

Converting an existing project into a workspace environment
```
git init
git add .
```

Commit all with one message
```
git commit -m "Initial Commit" -a
```

Commit one file
```
git commit -m "Initial Commit" file
```

Set Remote Origin
```
git remote add origin ssh://git@git.domain.tld/repository.git
git remote -v
```

Push Changes to Master
```
git push origin master
```

List all branches
```
git branch -a
```

Create brand new branch
```
git checkout -b develop
```

Or Switch to existing branch
```
git checkout develop
```

Create new feature branch
```
git checkout -b myfeature develop
```

Merge branches
```
git merge --no-ff myfeature
```

Delete branch
```
git branch -d myfeature # Deleted branch myfeature (was 05e9557).
```

First push of branch
```
git push -u origin my_branch
```

Psh changes to repository
```
$ git push origin develop
```

Clone sub-directory only
```
git clone https://github.com/devname/projectname.git customprojectname
cd customprojectname
git filter-branch --prune-empty --subdirectory-filter public/dist HEAD
```

List branches that can be deleted/pruned on local
```
git remote prune origin --dry-run
```

Run the prune/cleanup on local
```
git remote prune origin
```
