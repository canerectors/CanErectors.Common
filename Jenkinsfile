//def repo

node{
    repo = "${env.PIPELINE_SCRIPTS_REPO}"
	folder = "${env.PIPELINE_SCRIPTS_FOLDER}"
}

def nuget = fileLoader.fromGit(folder + '/nugetpublish', 
	repo, 'master', null, '')
    
nuget.publish()