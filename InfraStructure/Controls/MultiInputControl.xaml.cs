using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Collections;
using Phoenix.Infrastructure.Interfaces;

namespace TalentManager.Infrastructure.UserControls
{

    /// <summary>
    /// Interaction logic for UserControl2.xaml
    /// </summary>
    public partial class MultiInputControl : UserControl,INotifyPropertyChanged
    {
       public static DependencyProperty ObjectsListProperty = DependencyProperty.Register("ObjectsList",
                                                                                          typeof(ObservableCollection<ITaggableObject>), typeof(MultiInputControl), new PropertyMetadata(new PropertyChangedCallback(OnObjectsListChanged)));
        public ObservableCollection<ITaggableObject> ObjectsList
        {
            get { return (ObservableCollection<ITaggableObject>)GetValue(MultiInputControl.ObjectsListProperty); }
            set { SetValue(MultiInputControl.ObjectsListProperty, value); }

        }
        private static void OnObjectsListChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            MultiInputControl TargetObject = (MultiInputControl)d;
            ObservableCollection<ITaggableObject> TargetCollection = TargetObject.ObjectsList;
            if (TargetCollection == null) return;
            if (CollectionViewSource.GetDefaultView(TargetCollection).CurrentPosition == TargetCollection.Count - 1)
                TargetObject.IsAtLastPosition = true;
            else
                TargetObject.IsAtLastPosition = false;

            if (TargetCollection.Count == 0)
            {
                TargetObject.NavigateForward_Click(null, null);
            }
            else
                TargetObject.DeleteButton.IsEnabled = true;
        }

        //SelectedItem
        public static DependencyProperty SelectedItemProperty = DependencyProperty.Register("SelectedItem",
                                                                                         typeof(Object), typeof(MultiInputControl), new PropertyMetadata());
        public Object SelectedItem
        {
            get { return GetValue(MultiInputControl.SelectedItemProperty); }
            set { SetValue(MultiInputControl.SelectedItemProperty, value); }
        }

        //ItemtypeList
        public static DependencyProperty ItemtypesListProperty = DependencyProperty.Register("ItemtypesList",
                                                                                     typeof(List<string>), typeof(MultiInputControl), new PropertyMetadata());
        public List<string> ItemtypesList
        {
            get { return (List<string>)GetValue(MultiInputControl.ItemtypesListProperty); }
            set { SetValue(MultiInputControl.ItemtypesListProperty, value); }
        }
        public MultiInputControl()
        {
            InitializeComponent();
            DeleteButton.IsEnabled = false;
        }

        private UserControl _ViewTemplate;
        public UserControl ViewTemplate
        {
            get { return _ViewTemplate; }
            set { _ViewTemplate = value;

            }
        }

        private void NavigateBack_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (ObjectsList == null)
                    return;
                int currPos = CollectionViewSource.GetDefaultView(ObjectsList).CurrentPosition;
                if (!ObjectsList[currPos].IsEmpty)
                    if (!ObjectsList[currPos].Validate())
                        return;
                if (currPos > 0)
                {
                    CollectionViewSource.GetDefaultView(ObjectsList).MoveCurrentToPrevious();
                    OnPropertyChanged("NextButtonContent");
                    UpdateIsAtLastPosition();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void NavigateForward_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (ObjectsList == null)
                    return;
                int currPos = CollectionViewSource.GetDefaultView(ObjectsList).CurrentPosition;
                if (currPos > -1)
                {
                    if (ObjectsList[currPos].IsEmpty)
                        return;
                    if (!ObjectsList[currPos].Validate())
                        return;
                }
                if (currPos < ObjectsList.Count - 1)
                {
                    CollectionViewSource.GetDefaultView(ObjectsList).MoveCurrentToNext();
                    OnPropertyChanged("NextButtonContent");

                }
                else
                {
                    Type t = ItemsType;
                    Activator.CreateInstance(t);
                    Object newObject = Activator.CreateInstance(t);// t.GetConstructor(null).Invoke(null);
                    ObjectsList.Add((ITaggableObject)newObject);
                    CollectionViewSource.GetDefaultView(ObjectsList).MoveCurrentToNext();
                    OnPropertyChanged("ObjectsList");
                    DeleteButton.IsEnabled = true;
                }

                UpdateIsAtLastPosition();
            }
            catch (Exception ex)
            {
            }

        }

        private void UpdateIsAtLastPosition()
        {
            if (ObjectsList == null)
                return;
            if (CollectionViewSource.GetDefaultView(ObjectsList).CurrentPosition == ObjectsList.Count - 1)
                IsAtLastPosition = true;
            else
                IsAtLastPosition = false;
        }

        private bool _IsAtLastPosition;
        public bool IsAtLastPosition
        {
            get
            {
                return _IsAtLastPosition;
            }

            set
            {
                _IsAtLastPosition = value;
                OnPropertyChanged("IsAtLastPosition");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(String PropertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
            }
        }

        public Type ItemsType
        {
            get;
            set;
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            ObjectsList.RemoveAt(CollectionViewSource.GetDefaultView(ObjectsList).CurrentPosition);
            UpdateIsAtLastPosition();
            if (ObjectsList.Count == 0)
            {
                NavigateForward_Click(null, null);
            }
            else
                DeleteButton.IsEnabled = true;
        }

        public String SelectTypeString { get; set; }
        public bool IsTaggable { get; set; }

        private void itemButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Object parent = VisualTreeHelper.GetParent((DependencyObject)sender);
                while (parent.GetType() != typeof(ListBoxItem))
                {
                    parent = VisualTreeHelper.GetParent((DependencyObject)parent);

                }

                if (parent != null)
                    ((ListBoxItem)parent).IsSelected = true;
                UpdateIsAtLastPosition();
            }
            catch (Exception ex)
            {
            }
        }

        private void buttons_list_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateIsAtLastPosition();
        }
    }
}
