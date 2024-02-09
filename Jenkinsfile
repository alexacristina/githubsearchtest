pipeline {
    agent any
    stages {
        stage 'Checkout'
            checkout scm

        stage 'Build'
            bat "\"C:/Program Files/dotnet/dotnet.exe\" restore \"${workspace}/TestSearchRepoQueries.sln\""
            bat "\"C:/Program Files/dotnet/dotnet.exe\" build \"${workspace}/TestSearchRepoQueries.sln\""

        stage 'UnitTests'
            bat returnStatus: true, script: "\"C:/Program Files/dotnet/dotnet.exe\" test \"${workspace}/TestSearchRepoQueries.sln\" --logger \"trx;LogFileName=unit_tests.xml\" --no-build"
            step {[$class: 'nunit', testResultsPattern: "**/unit_tests.xml", failIfNoResults: true, failedTestsFailBuild: true]}, 
    }

}