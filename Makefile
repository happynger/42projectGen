# **************************************************************************** #
#                                                                              #
#                                                         :::      ::::::::    #
#    Makefile                                           :+:      :+:    :+:    #
#                                                     +:+ +:+         +:+      #
#    By: otahirov <otahirov@student.42.fr>          +#+  +:+       +#+         #
#                                                 +#+#+#+#+#+   +#+            #
#    Created: 2018/09/17 22:20:55 by otahirov          #+#    #+#              #
#    Updated: 2018/09/19 17:20:08 by otahirov         ###   ########.fr        #
#                                                                              #
# **************************************************************************** #

PATH_EX = ./Executable
PATH_EX_FULL = ../Executable
PATH_RELEASE_FULL = ./Source/bin/Release/netcoreapp2.1/osx.10.13-x64
PATH_RELEASE = ./Source/bin/Release
PATH_ASSETS = ./Source/assets
PATH_PROJECT = ./Source/

all : publish

publish : clean
	dotnet publish $(PATH_PROJECT) -c Release -f netcoreapp2.1 -r osx.10.13-x64 -o $(PATH_EX_FULL)/
	mkdir $(PATH_EX)/assets

copy : clean
	mv $(PATH_RELEASE_FULL)/* $(PATH_EX)/
	rm -rf $(PATH_RELEASE)/*
	rm -rf $(PATH_RELEASE)/
	mkdir $(PATH_EX)/assets
	cp $(PATH_ASSETS)/* $(PATH_EX)/assets/

clean :
	rm -rf $(PATH_EX)/*
