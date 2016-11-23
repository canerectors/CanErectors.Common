def repo

node{
    repo = "${env.PIPELINE_SCRIPTS_REPO}"
}

def nuget = fileLoader.fromGit('commonlibs.groovy/nugetpublish', 
			       repo, 'master', null, '')
    
nuget.publish()

